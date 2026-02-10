using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <summary>
/// Handle to a texture on the GPU.
/// 
/// It can be created with <see cref="DeviceHandle.CreateTexture(TextureDescriptor)" />.
/// </summary>
public sealed class Texture :
    WebGPUManagedHandleBase<TextureHandle>,
    IFromHandle<Texture, TextureHandle>
{
    /// <inheritdoc cref="WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED"/>
    public const uint MIP_LEVEL_COUNT_UNDEFINED = WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED;

    private Texture(TextureHandle handle) : base(handle)
    {
    }

    /// <summary>
    /// Handle to a texture on the GPU.
    /// 
    /// It can be created with <see cref="DeviceHandle.CreateTexture(TextureDescriptor)" />.
    /// </summary>
    public TextureView CreateView(in TextureViewDescriptor textureViewDescriptor) =>
        Handle.CreateView(textureViewDescriptor).ToSafeHandle()!;

    /// <inheritdoc cref="TextureHandle.CreateView"/>
    public TextureView CreateView() => Handle.CreateView().ToSafeHandle()!;
    /// <inheritdoc cref="TextureHandle.Destroy"/>
    public void Destroy() => Handle.Destroy();
    /// <inheritdoc cref="TextureHandle.GetDepthOrArrayLayers"/>
    public uint GetDepthOrArrayLayers() => Handle.GetDepthOrArrayLayers();
    /// <inheritdoc cref="TextureHandle.GetDimension"/>
    public TextureDimension GetDimension() => Handle.GetDimension();
    /// <inheritdoc cref="TextureHandle.GetFormat"/>
    public TextureFormat GetFormat() => Handle.GetFormat();
    /// <inheritdoc cref="TextureHandle.GetHeight"/>
    public uint GetHeight() => Handle.GetHeight();
    /// <inheritdoc cref="TextureHandle.GetMipLevelCount"/>
    public uint GetMipLevelCount() => Handle.GetMipLevelCount();
    /// <inheritdoc cref="TextureHandle.GetSampleCount"/>
    public uint GetSampleCount() => Handle.GetSampleCount();
    /// <inheritdoc cref="TextureHandle.GetUsage"/>
    public TextureUsage GetUsage() => Handle.GetUsage();
    /// <inheritdoc cref="TextureHandle.GetWidth"/>
    public uint GetWidth() => Handle.GetWidth();
    /// <inheritdoc cref="TextureHandle.SetLabel"/>
    public void SetLabel(WGPURefText label) => Handle.SetLabel(label);

    public TextureViewDimension GetTextureBindingViewDimension() => WebGPU_FFI.TextureGetTextureBindingViewDimension(Handle);

    static Texture? IFromHandle<Texture, TextureHandle>.FromHandle(
        TextureHandle handle)
    {
        if (TextureHandle.IsNull(handle))
        {
            return null;
        }

        TextureHandle.Reference(handle);
        return new(handle);
    }
}
