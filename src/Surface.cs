using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Surface : WebGpuSafeHandle<SurfaceHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<SurfaceHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<SurfaceHandle> Create(SurfaceHandle handle)
        {
            return new Surface(handle);
        }
    }

    private Surface(SurfaceHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.SurfaceReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.SurfaceRelease(_handle);
    }

    internal static Surface? FromHandle(SurfaceHandle handle, bool incrementReferenceCount = true)
    {
        var newSurface = WebGpuSafeHandleCache<SurfaceHandle>.GetOrCreate<CacheFactory>(handle) as Surface;
        if (incrementReferenceCount && newSurface != null)
        {
            newSurface.AddReference(false);
        }
        return newSurface;
    }

    public TextureFormat GetPreferredFormat(Adapter adapter) => _handle.GetPreferredFormat(adapter.GetHandle());
}