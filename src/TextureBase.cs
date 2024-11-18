using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class TextureBase : WebGPUHandleWrapperBase<TextureHandle>
{
    public TextureView CreateView(in TextureViewDescriptor textureViewDescriptor) => 
        Handle.CreateView(textureViewDescriptor).ToSafeHandle(false)!;
        
    public TextureView CreateView() => Handle.CreateView().ToSafeHandle(false)!;
    public void Destroy() => Handle.Destroy();
    public uint GetDepthOrArrayLayers() => Handle.GetDepthOrArrayLayers();
    public TextureDimension GetDimension() => Handle.GetDimension();
    public TextureFormat GetFormat() => Handle.GetFormat();
    public uint GetHeight() => Handle.GetHeight();
    public uint GetMipLevelCount() => Handle.GetMipLevelCount();
    public uint GetSampleCount() => Handle.GetSampleCount();
    public TextureUsage GetUsage() => Handle.GetUsage();
    public uint GetWidth() => Handle.GetWidth();
    public void SetLabel(WGPURefText label) => Handle.SetLabel(label);
}
