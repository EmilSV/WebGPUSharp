using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Surface : BaseWebGpuSafeHandle<Surface, SurfaceHandle>
{
    private Surface(SurfaceHandle handle) : base(handle)
    {
    }

    internal static Surface? FromHandle(SurfaceHandle handle, bool isOwnedHandle)
    {
        var newSurface = WebGpuSafeHandleCache.GetOrCreate(handle, static handle => new Surface(handle));
        if (isOwnedHandle)
        {
            newSurface?.AddReference(false);
        }
        return newSurface;
    }

    public TextureFormat GetPreferredFormat(Adapter adapter) => _handle.GetPreferredFormat(adapter);
}