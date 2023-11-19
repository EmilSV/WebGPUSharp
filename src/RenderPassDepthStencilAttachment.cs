using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct RenderPassDepthStencilAttachment :
     IWebGpuFFIConvertible<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>
{
    public TextureViewSource View;
    public LoadOp DepthLoadOp;
    public StoreOp DepthStoreOp;
    public float DepthClearValue;
    public bool DepthReadOnly;
    public LoadOp StencilLoadOp;
    public StoreOp StencilStoreOp;
    public uint StencilClearValue;
    public bool StencilReadOnly;



    static void IWebGpuFFIConvertible<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassDepthStencilAttachment input, out RenderPassDepthStencilAttachmentFFI dest)
    {
        dest.View = input.View.GetHandle();
        dest.DepthLoadOp = input.DepthLoadOp;
        dest.DepthStoreOp = input.DepthStoreOp;
        dest.DepthClearValue = input.DepthClearValue;
        dest.DepthReadOnly = input.DepthReadOnly;
        dest.StencilLoadOp = input.StencilLoadOp;
        dest.StencilStoreOp = input.StencilStoreOp;
        dest.StencilClearValue = input.StencilClearValue;
        dest.StencilReadOnly = input.StencilReadOnly;
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassDepthStencilAttachment input, WebGpuAllocatorHandle allocator, out RenderPassDepthStencilAttachmentFFI dest)
    {
        ToFFI(in input, out dest);
    }
}