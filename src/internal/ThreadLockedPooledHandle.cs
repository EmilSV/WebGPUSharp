using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;


internal unsafe sealed class ThreadLockedPooledHandle<T>
    where T : unmanaged, IWebGpuHandle<T>
{
    private static ulong nextToken = 1;
    private static readonly ConcurrentQueue<ThreadLockedPooledHandle<T>> _pool = new();
    public static ThreadLockedPooledHandle<T> Get(T handle)
    {
        var token = Interlocked.Increment(ref nextToken);
        if (token == 0)
        {
            token = Interlocked.Increment(ref nextToken);
        }

        if (_pool.TryDequeue(out var result))
        {
            result.Token = token;
            result.Handle = handle;
            return result;
        }

        return new ThreadLockedPooledHandle<T>(token, handle);
    }

    public static void Return(ThreadLockedPooledHandle<T> ThreadLockedPooledHandle)
    {
        var oldHandle = ThreadLockedPooledHandle.Handle;
        ref var ptr = ref T.AsPointer(ref ThreadLockedPooledHandle.Handle);
        var oldPtr = T.AsPointer(ref oldHandle);
        if (oldPtr == UIntPtr.Zero)
        {
            return;
        }

        if (Interlocked.CompareExchange(ref ptr, UIntPtr.Zero, oldPtr) != oldPtr)
        {
            return;
        }

        T.Release(oldHandle);
        ThreadLockedPooledHandle.Token = 0;

        _pool.Enqueue(ThreadLockedPooledHandle);
    }

    public ulong Token;
    public int ManagedThreadId;
    public T Handle;

    private ThreadLockedPooledHandle(ulong token, T handle)
    {
        this.Token = token;
        this.ManagedThreadId = Environment.CurrentManagedThreadId;
        this.Handle = handle;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void VerifyToken(ulong localToken)
    {
        if (Volatile.Read(ref Token) != localToken)
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid state.");
        }
        if (Environment.CurrentManagedThreadId != ManagedThreadId)
        {
            throw new WebGPUUsedOnWrongThreadException($"{typeof(T).Name} is being accessed from a different thread.");
        }
    }

    public T GetHandle(ulong localToken)
    {
        VerifyToken(localToken);
        var oldHandle = Handle;
        if (T.IsNull(oldHandle))
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid state.");
        }
        return oldHandle;
    }

    ~ThreadLockedPooledHandle()
    {
        if (!T.IsNull(Handle))
        {
            T.Release(Handle);
        }
    }
}