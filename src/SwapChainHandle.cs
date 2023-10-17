
using WebGpuSharp.FFI;

namespace WebGpuSharp.FFI;

public readonly partial struct SwapChainHandle : IDisposable
{
    public TextureViewHandle GetCurrentTextureView() => WebGPU_FFI.SwapChainGetCurrentTextureView(this);
    public TextureHandle GetCurrentTexture() => WebGPU_FFI.SwapChainGetCurrentTexture(this);
    public void Present() => WebGPU_FFI.SwapChainPresent(this);

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.SwapChainRelease(this);
        }
    }
}