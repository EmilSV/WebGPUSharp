using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal readonly struct ThreadLockedPooledHandle<T>
    where T : unmanaged, IWebGpuHandle<T>
{
    private readonly ThreadLockedPooledHandleItem _item;

    private ThreadLockedPooledHandle(ThreadLockedPooledHandleItem item)
    {
        _item = item;
    }

    public static ThreadLockedPooledHandle<T> Get(T handle)
    {
        return new ThreadLockedPooledHandle<T>(ThreadLockedPooledHandleItem.Get(handle));
    }

    public static void Return(ThreadLockedPooledHandle<T> ThreadLockedPooledHandle)
    {
        ThreadLockedPooledHandleItem.Return<T>(ThreadLockedPooledHandle._item);
    }


    public readonly ulong Token => _item.Token;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void VerifyToken(ulong localToken)
    {
        _item.VerifyToken<T>(localToken);
    }

    public readonly T GetHandle(ulong localToken)
    {
        return _item.GetHandle<T>(localToken);
    }
}

internal unsafe sealed class ThreadLockedPooledHandleItem
{

    private static ulong _nextToken = 1;
    [ThreadStatic] private static InlineArray4<ThreadLockedPooledHandleItem?> _pool;

    private delegate*<nuint, void> _releaseFunction;
    private nuint _handle;
    private ulong _token;
    private readonly int _owningThreadId;

    public ulong Token => _token;

    private ThreadLockedPooledHandleItem(ulong token, nuint handle, delegate*<nuint, void> releaseFunction)
    {
        _owningThreadId = Environment.CurrentManagedThreadId;
        _handle = handle;
        _token = token;
        _releaseFunction = releaseFunction;
    }

    private static ulong GetNextToken()
    {
        var token = Interlocked.Increment(ref _nextToken);
        if (token == 0)
        {
            token = Interlocked.Increment(ref _nextToken);
        }
        return token;
    }


    public unsafe static ThreadLockedPooledHandleItem Get<T>(T handle)
        where T : unmanaged, IWebGpuHandle<T>
    {
        if (sizeof(T) != sizeof(nuint))
        {
            throw new InvalidOperationException("Invalid handle size.");
        }

        delegate*<T, void> releaseFunction = &T.Release;

        Span<ThreadLockedPooledHandleItem?> pool = _pool;
        for (int i = 0; i < pool.Length; i++)
        {
            var item = pool[i];
            if (item != null)
            {
                pool[i] = null;
                item._token = GetNextToken();
                item._handle = Unsafe.BitCast<T, nuint>(handle);
                item._releaseFunction = (delegate*<nuint, void>)(void*)releaseFunction;
                return item;
            }
        }

        return new ThreadLockedPooledHandleItem(GetNextToken(), Unsafe.BitCast<T, nuint>(handle), (delegate*<nuint, void>)(void*)releaseFunction);
    }

    public static void Return<T>(ThreadLockedPooledHandleItem item)
        where T : unmanaged, IWebGpuHandle<T>
    {
        if (sizeof(T) != sizeof(nuint))
        {
            throw new InvalidOperationException("Invalid handle size.");
        }

        if (item._owningThreadId != Environment.CurrentManagedThreadId)
        {
            throw new InvalidOperationException("Cannot return handle from a different thread.");
        }

        var handle = item._handle;
        if (handle == 0)
        {
            return;
        }
        item._handle = 0;

        T.Release(Unsafe.BitCast<nuint, T>(handle));
        item._releaseFunction = null;
        item._token = 0;

        Span<ThreadLockedPooledHandleItem?> pool = _pool;
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i] == null)
            {
                pool[i] = item;
                return;
            }
        }

        // Pool is full, let the item be collected. stop finalize from running as there is nothing to release.
        GC.SuppressFinalize(item);
    }


    public T GetHandle<T>(ulong localToken)
        where T : unmanaged, IWebGpuHandle<T>
    {
        if (sizeof(T) != sizeof(nuint))
        {
            throw new InvalidOperationException("Invalid handle size.");
        }

        if (_owningThreadId != Environment.CurrentManagedThreadId)
        {
            throw new InvalidOperationException("Cannot access handle from a different thread.");
        }

        if (_token != localToken)
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid state.");
        }

        var handle = _handle;
        if (handle == 0)
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid state.");
        }

        return Unsafe.BitCast<nuint, T>(handle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void VerifyToken<T>(ulong localToken)
    {
        if (_owningThreadId != Environment.CurrentManagedThreadId)
        {
            throw new InvalidOperationException("Cannot access handle from a different thread.");
        }

        if (_token != localToken)
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid state.");
        }
    }

    ~ThreadLockedPooledHandleItem()
    {
        if (_releaseFunction != null)
        {
            _releaseFunction(_handle);
        }
    }
}

