using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class SwapChain : BaseWebGpuSafeHandle<SwapChainHandle>
{
    public SwapChain(SwapChainHandle handle) : base(handle)
    {
    }

    internal static SwapChain? FromHandle(SwapChainHandle handle, bool incrementReferenceCount)
    {
        var newSwapChain = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new SwapChain(handle));
        newSwapChain?.AddReference(incrementReferenceCount);
        return newSwapChain;
    }

    public TextureView? GetCurrentTextureView() => _handle.GetCurrentTextureView().ToSafeHandle(true);
    public Texture? GetCurrentTexture() => _handle.GetCurrentTexture().ToSafeHandle(true);
    public void Present() => _handle.Present();
}