using WebGpuSharp.FFI;

namespace WebGpuSharp;

public interface ITextureSource
{
    Texture? GetCurrentTexture();
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    TextureHandle UnsafeGetCurrentOwnedTextureHandle();
}