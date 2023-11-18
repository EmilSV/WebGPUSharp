using WebGpuSharp.FFI;

namespace WebGpuSharp;

interface ITextureViewSource
{
    TextureView? GetCurrentTextureView();
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    TextureViewHandle UnsafeGetCurrentTextureViewHandle();
}