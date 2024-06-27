using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Texture :
    BaseWebGpuSafeHandle<Texture, TextureHandle>,
    ITextureSource
{
    public const uint MIP_LEVEL_COUNT_UNDEFINED = WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED;

    private Texture(TextureHandle handle) : base(handle)
    {
    }

    internal static Texture? FromHandle(TextureHandle handle, bool isOwnedHandle)
    {
        var newTexture = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new Texture(handle));
        if (isOwnedHandle)
        {
            newTexture?.AddReference(false);
        }
        return newTexture;
    }

    public TextureView? CreateView(in TextureViewDescriptor textureViewDescriptor)
    {
        return _handle.CreateView(textureViewDescriptor).ToSafeHandle(false);
    }

    public void Destroy() => _handle.Destroy();



    public uint GetDepthOrArrayLayers() => _handle.GetDepthOrArrayLayers();
    public TextureDimension GetDimension() => _handle.GetDimension();
    public TextureFormat GetFormat() => _handle.GetFormat();
    public uint GetHeight() => _handle.GetHeight();
    public uint GetMipLevelCount() => _handle.GetMipLevelCount();
    public uint GetSampleCount() => _handle.GetSampleCount();
    public TextureUsage GetUsage() => _handle.GetUsage();
    public uint GetWidth() => _handle.GetWidth();
    public void SetLabel(WGPURefText label) => _handle.SetLabel(label);

    Texture? ITextureSource.GetCurrentTexture()
    {
        return this;
    }

    TextureHandle ITextureSource.UnsafeGetCurrentTextureHandle()
    {
        return _handle;
    }
}
