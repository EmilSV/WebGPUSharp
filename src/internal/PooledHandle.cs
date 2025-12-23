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
            result.Token = token;
            result.Handle = handle;
            return result;
        }

        return new PooledHandle<T>(token, handle);
    }

    public static void Return(PooledHandle<T> pooledHandle)
    {
        var oldHandle = pooledHandle.Handle;
        ref var ptr = ref T.AsPointer(ref pooledHandle.Handle);
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
        pooledHandle.Token = 0;

        _pool.Enqueue(pooledHandle);
    }

    public ulong Token;
    public T Handle;

    private PooledHandle(ulong token, T handle)
    {
        this.Token = token;
        this.Handle = handle;
    }


    public void VerifyToken(ulong localToken)
    {
        if (Interlocked.Read(ref Token) != localToken)
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid.");
        }
    }

    public T GetHandle(ulong localToken)
    {
        VerifyToken(localToken);
        var oldHandle = Handle;
        if (T.IsNull(oldHandle))
        {
            throw new WebGPUInvalidStateException($"{typeof(T).Name} is in invalid.");
        }
        return oldHandle;
    }

    ~PooledHandle()
    {
        if (!T.IsNull(Handle))
        {
            T.Release(Handle);
        }
    }
}