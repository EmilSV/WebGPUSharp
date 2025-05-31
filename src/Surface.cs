using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class Surface :
    SurfaceBase,
    IFromHandle<Surface, SurfaceHandle>
{
    private readonly WebGpuSafeHandle<SurfaceHandle> _safeHandle;

    protected override SurfaceHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private Surface(SurfaceHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<SurfaceHandle>(handle);
    }

    static Surface? IFromHandle<Surface, SurfaceHandle>.FromHandle(SurfaceHandle handle)
    {
        if (SurfaceHandle.IsNull(handle))
        {
            return null;
        }

        SurfaceHandle.Reference(handle);
        return new(handle);
    }

    static Surface? IFromHandle<Surface, SurfaceHandle>.FromHandleNoRefIncrement(SurfaceHandle handle)
    {
        if (SurfaceHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}