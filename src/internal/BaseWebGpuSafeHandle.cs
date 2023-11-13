using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public abstract class BaseWebGpuSafeHandle<TSelf, THandle> :
    BaseWebGpuSafeHandle<THandle>,
    IWebGpuFFIConvertible<TSelf, THandle>
    where TSelf : BaseWebGpuSafeHandle<TSelf, THandle>
    where THandle : unmanaged, IWebGpuHandle<THandle>
{
    internal BaseWebGpuSafeHandle(THandle handle) : base(handle)
    {
    }

    static void IWebGpuFFIConvertible<TSelf, THandle>.UnsafeConvertToFFI(in TSelf input, out THandle dest)
    {
        dest = input.GetHandle();
    }

    static void IWebGpuFFIConvertibleAlloc<TSelf, THandle>.UnsafeConvertToFFI(in TSelf input, WebGpuAllocatorHandle allocator, out THandle dest)
    {
        dest = input.GetHandle();
    }
}

public abstract class BaseWebGpuSafeHandle<THandle>
    where THandle : unmanaged, IWebGpuHandle<THandle>
{
    protected THandle _handle;
    private int _referenceCount = 0;

    internal BaseWebGpuSafeHandle(THandle handle)
    {
        _handle = handle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void AddReference(bool incrementWebGpu)
    {
        Interlocked.Increment(ref _referenceCount);
        if (incrementWebGpu)
        {
            THandle.Reference(_handle);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal THandle GetHandle() => _handle;

    public static explicit operator THandle(BaseWebGpuSafeHandle<THandle>? safeHandle)
    {
        if(safeHandle == null)
        {
            return THandle.Null;
        }

        return safeHandle._handle;
    }

    ~BaseWebGpuSafeHandle()
    {
        int localReferenceCount = Interlocked.Exchange(ref _referenceCount, 0);
        if (localReferenceCount == 0)
        {
            return;
        }

        while (Interlocked.Decrement(ref _referenceCount) >= 0)
        {
            THandle.Release(_handle);

        }

        WebGpuSafeHandleCache.RemoveHandle(_handle);
    }
}