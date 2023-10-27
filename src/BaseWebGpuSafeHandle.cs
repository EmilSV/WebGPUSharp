using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

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

    ~BaseWebGpuSafeHandle()
    {
        int localReferenceCount = Interlocked.Exchange(ref _referenceCount, _referenceCount);
        if (localReferenceCount == 0)
        {
            return;
        }

        while (Interlocked.Decrement(ref _referenceCount) > 0)
        {
            THandle.Release(_handle);
        }

        WebGpuSafeHandleCache.RemoveHandle(_handle);
    }
}