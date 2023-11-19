using System;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class SwapChain :
    BaseWebGpuSafeHandle<SwapChainHandle>,
    ITextureSource,
    ITextureViewSource
{
    private TextureViewHandle _currentTextureViewHandle = TextureViewHandle.Null;
    private TextureHandle _currentTextureHandle = TextureHandle.Null;


    public SwapChain(SwapChainHandle handle) : base(handle)
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
    public void Present()
    {
        _handle.Present();

        if (_currentTextureHandle != TextureHandle.Null)
        {
            TextureViewHandle oldTextureViewHandle = _currentTextureViewHandle;
            if (WebGPUHandleInterlock.CompareExchange(
                ref _currentTextureViewHandle, TextureViewHandle.Null, oldTextureViewHandle) == oldTextureViewHandle)
            {
                oldTextureViewHandle.Dispose();
            }
        }

        if (_currentTextureHandle != TextureHandle.Null)
        {
            TextureHandle oldTextureHandle = _currentTextureHandle;
            if (WebGPUHandleInterlock.CompareExchange(
                ref _currentTextureHandle, TextureHandle.Null, oldTextureHandle) == oldTextureHandle)
            {
                oldTextureHandle.Dispose();
            }
        }
    }

    ~SwapChain()
    {
        if (_currentTextureHandle != TextureHandle.Null)
        {
            TextureViewHandle oldTextureViewHandle = _currentTextureViewHandle;
            if (WebGPUHandleInterlock.CompareExchange(
                ref _currentTextureViewHandle, TextureViewHandle.Null, oldTextureViewHandle) == oldTextureViewHandle)
            {
                oldTextureViewHandle.Dispose();
            }
        }

        if (_currentTextureHandle != TextureHandle.Null)
        {
            TextureHandle oldTextureHandle = _currentTextureHandle;
            if (WebGPUHandleInterlock.CompareExchange(
                ref _currentTextureHandle, TextureHandle.Null, oldTextureHandle) == oldTextureHandle)
            {
                oldTextureHandle.Dispose();
            }
        }
    }

    TextureViewHandle ITextureViewSource.UnsafeGetCurrentTextureViewHandle()
    {
        TextureViewHandle newTextureViewHandle = _handle.GetCurrentTextureView();
        TextureViewHandle oldTextureViewHandle = WebGPUHandleInterlock.Exchange(ref _currentTextureViewHandle, newTextureViewHandle);
        if (oldTextureViewHandle != TextureViewHandle.Null)
        {
            oldTextureViewHandle.Dispose();
        }

        return newTextureViewHandle;
    }

    TextureHandle ITextureSource.UnsafeGetCurrentTextureHandle()
    {
        TextureHandle newTextureHandle = _handle.GetCurrentTexture();
        TextureHandle oldTextureHandle = WebGPUHandleInterlock.Exchange(ref _currentTextureHandle, newTextureHandle);
        if (oldTextureHandle != TextureHandle.Null)
        {
            oldTextureHandle.Dispose();
        }

        return newTextureHandle;
    }
}