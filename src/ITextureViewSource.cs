using WebGpuSharp.FFI;

namespace WebGpuSharp;

public interface ITextureViewSource
{
    TextureView? GetCurrentTextureView();
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    TextureViewHandle UnsafeGetCurrentTextureViewHandle();
}