using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <summary>
/// Handle to a texture on the GPU.
/// 
/// It can be created with <see cref="DeviceHandle.CreateTexture(TextureDescriptor)" />.
/// </summary>
public abstract class TextureBase : WebGPUHandleWrapperBase<TextureHandle>
{
    /// <summary>
    /// Handle to a texture on the GPU.
    /// 
    /// It can be created with <see cref="DeviceHandle.CreateTexture(TextureDescriptor)" />.
    /// </summary>
    public TextureView CreateView(in TextureViewDescriptor textureViewDescriptor) =>
        Handle.CreateView(textureViewDescriptor).ToSafeHandle(false)!;

    /// <inheritdoc cref="TextureHandle.CreateView"/>
    public TextureView CreateView() => Handle.CreateView().ToSafeHandle(false)!;
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
}
