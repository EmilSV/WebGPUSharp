using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe struct SurfaceTexture
{
    private SurfaceTextureFFI _innerSurfaceTextureFFI;
    public Texture? Texture { get; private set; }
    public WebGPUBool Suboptimal => _innerSurfaceTextureFFI.Suboptimal;
    public SurfaceGetCurrentTextureStatus Status => _innerSurfaceTextureFFI.Status;

    internal void InternalSetSurfaceTextureFFI(SurfaceHandle surface)
    {
        surface.GetCurrentTexture(ref _innerSurfaceTextureFFI);
        Texture = _innerSurfaceTextureFFI.Texture.ToSafeHandle(false);
        _innerSurfaceTextureFFI.Texture = default;
    }
}