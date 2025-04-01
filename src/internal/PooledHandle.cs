using System.Collections.Concurrent;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;


internal unsafe sealed class PooledHandle<T>
    where T : unmanaged, IWebGpuHandle<T>
{
    private static ulong nextToken = 1;
    private static readonly ConcurrentQueue<PooledHandle<T>> _pool = new();
    public static PooledHandle<T> Get(T handle)
    {
        var token = Interlocked.Increment(ref nextToken);
        if (token == 0)
        {
            token = Interlocked.Increment(ref nextToken);
        }

        if (_pool.TryDequeue(out var result))
        {
            result.token = token;
            result.handle = handle;
            return result;
        }

        return new PooledHandle<T>(token, handle);
    }

    public static void Return(PooledHandle<T> pooledHandle)
    {
        var oldHandle = pooledHandle.handle;
        ref var ptr = ref T.AsPointer(ref pooledHandle.handle);
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
        pooledHandle.token = 0;

        _pool.Enqueue(pooledHandle);
    }

    public ulong token;
    public T handle;

    private PooledHandle(ulong token, T handle)
    {
        this.token = token;
        this.handle = handle;
    }


    public void VerifyToken(ulong localToken)
    {
        if (Interlocked.Read(ref token) != localToken)
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid.");
        }
    }

    public T GetOwnedHandle(ulong localToken)
    {
        VerifyToken(localToken);
        var oldHandle = handle;
        if (T.IsNull(oldHandle))
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid.");
        }
        T.Reference(oldHandle);
        return oldHandle;
    }

    ~PooledHandle()
    {
        if (!T.IsNull(handle))
        {
            T.Release(handle);
        }
    }
}