using WebGpuSharp.FFI;

namespace WebGpuSharp;

interface ITextureSource
{
    Texture? GetCurrentTexture();
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    TextureHandle UnsafeGetCurrentTextureHandle();
}