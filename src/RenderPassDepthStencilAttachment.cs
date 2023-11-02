using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct RenderPassDepthStencilAttachment :
     IWebGpuFFIConvertible<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>
{
    public TextureView View;
    public LoadOp DepthLoadOp;
    public StoreOp DepthStoreOp;
    public float DepthClearValue;
    public bool DepthReadOnly;
    public LoadOp StencilLoadOp;
    public StoreOp StencilStoreOp;
    public uint StencilClearValue;
    public bool StencilReadOnly;



    static void IWebGpuFFIConvertible<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>.UnsafeMarshalTo(
        in RenderPassDepthStencilAttachment input, ref RenderPassDepthStencilAttachmentFFI dest)
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

    static void IWebGpuFFIConvertibleAlloc<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>.UnsafeMarshalTo(
        in RenderPassDepthStencilAttachment input, WebGpuAllocatorHandle allocator, ref RenderPassDepthStencilAttachmentFFI dest)
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
}