using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public abstract class WebGpuSafeHandle<T>
    where T : unmanaged, IWebGpuHandle<T>
{
    protected T _handle;
    private int _referenceCount = 0;

    internal WebGpuSafeHandle(T handle)
    {
        _handle = handle;
    }

    internal void AddReference(bool incrementWebGpu)
    {
        Interlocked.Increment(ref _referenceCount);
        if (incrementWebGpu)
        {
            WebGpuReference();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T GetHandle() => _handle;

    protected abstract void WebGpuReference();
    protected abstract void WebGpuRelease();

    ~WebGpuSafeHandle()
    {
        int localReferenceCount = Interlocked.Exchange(ref _referenceCount, _referenceCount);
        if (localReferenceCount == 0)
        {
            return;
        }

        while (Interlocked.Decrement(ref _referenceCount) > 0)
        {
            WebGpuRelease();
        }

        WebGpuSafeHandleCache<T>.RemoveHandle(_handle);
    }
}