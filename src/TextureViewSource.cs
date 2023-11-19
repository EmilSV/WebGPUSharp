using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public readonly struct TextureViewSource
{
    private readonly TextureViewHandle _textureViewHandle;
    private readonly ITextureViewSource? _textureViewSource;


    public TextureViewSource(TextureViewHandle textureViewHandle)
    {
        _textureViewHandle = textureViewHandle;
        _textureViewSource = null;
    }

    public TextureViewSource(ITextureViewSource textureViewSource)
    {
        _textureViewHandle = TextureViewHandle.Null;
        _textureViewSource = textureViewSource;
    }

    public bool HasValue()
    {
        return _textureViewHandle != TextureViewHandle.Null || _textureViewSource != null;
    }


    public static implicit operator TextureViewSource(TextureViewHandle textureViewHandle)
    {
        return new TextureViewSource(textureViewHandle);
    }

    public static implicit operator TextureViewSource(SwapChain swapChain)
    {
        return new TextureViewSource(swapChain);
    }

    public static implicit operator TextureViewSource(TextureView textureView)
    {
        return new TextureViewSource(textureView);
    }

    internal TextureViewHandle GetHandle()
    {
        return _textureViewSource != null ?
            _textureViewSource.UnsafeGetCurrentTextureViewHandle() :
            _textureViewHandle;
    }
}