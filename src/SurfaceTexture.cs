using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="SurfaceTextureFFI"/>
public unsafe struct SurfaceTexture
{
    private SurfaceTextureFFI _innerSurfaceTextureFFI;
    /// <inheritdoc cref="SurfaceTextureFFI.Texture"/>
    public Texture? Texture { get; private set; }
    /// <inheritdoc cref="SurfaceTextureFFI.Status"/>
    public readonly SurfaceGetCurrentTextureStatus Status => _innerSurfaceTextureFFI.Status;

    internal void InternalSetSurfaceTextureFFI(SurfaceHandle surface)
    {
        surface.GetCurrentTexture(ref _innerSurfaceTextureFFI);
        Texture = _innerSurfaceTextureFFI.Texture.ToSafeHandle(false);
        _innerSurfaceTextureFFI.Texture = default;
    }
}