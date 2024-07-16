using System;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class SwapChain :
    BaseWebGpuSafeHandle<SwapChainHandle>,
    ITextureSource,
    ITextureViewSource
{
    private SwapChain(SwapChainHandle handle) : base(handle)
    {
    }

    internal static SwapChain? FromHandle(SwapChainHandle handle, bool isOwnedHandle)
    {
        var newSwapChain = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new SwapChain(handle));
        if (isOwnedHandle)
        {
            newSwapChain?.AddReference(false);
        }
        return newSwapChain;
    }

    public TextureView? GetCurrentTextureView() => _handle.GetCurrentTextureView().ToSafeHandle(true);
    public Texture? GetCurrentTexture() => _handle.GetCurrentTexture().ToSafeHandle(true);
    public void Present() => _handle.Present();

    TextureHandle ITextureSource.UnsafeGetCurrentOwnedTextureHandle()
    {
        return _handle.GetCurrentTexture();
    }

    TextureViewHandle ITextureViewSource.UnsafeGetCurrentTextureViewOwnedHandle()
    {
        var currentTextureViewHandle = _handle.GetCurrentTextureView();
        return currentTextureViewHandle;
    }
}