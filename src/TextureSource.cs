using WebGpuSharp.FFI;

namespace WebGpuSharp;

public readonly struct TextureSource
{
    private readonly TextureHandle _textureHandle;
    private readonly ITextureSource? _textureSource;


    public TextureSource(TextureHandle textureHandle)
    {
        _textureHandle = textureHandle;
        _textureSource = null;
    }

    public TextureSource(ITextureSource textureSource)
    {
        _textureHandle = TextureHandle.Null;
        _textureSource = textureSource;
    }

    public bool HasValue()
    {
        return _textureHandle != TextureHandle.Null || _textureSource != null;
    }

    public static implicit operator TextureSource(TextureHandle textureHandle)
    {
        return new TextureSource(textureHandle);
    }

    public static implicit operator TextureSource(SwapChain swapChain)
    {
        return new TextureSource(swapChain);
    }

    public static implicit operator TextureSource(Texture texture)
    {
        return new TextureSource(texture);
    }

    internal TextureHandle GetHandle()
    {
        return _textureSource != null ?
            _textureSource.UnsafeGetCurrentTextureHandle() :
            _textureHandle;
    }
}