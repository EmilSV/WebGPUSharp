using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct RenderPassDepthStencilAttachment :
     IWebGpuFFIConvertibleAlloc<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>
{
    public required ITextureViewSource View;
    public LoadOp DepthLoadOp;
    public StoreOp DepthStoreOp;
    public float DepthClearValue;
    public bool DepthReadOnly = false;
    public LoadOp StencilLoadOp;
    public StoreOp StencilStoreOp;
    public uint StencilClearValue = 0;
    public bool StencilReadOnly = false;

    public RenderPassDepthStencilAttachment()
    {
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassDepthStencilAttachment input, WebGpuAllocatorHandle allocator, out RenderPassDepthStencilAttachmentFFI dest)
    {
        var ownedViewHandle = input.View.UnsafeGetCurrentTextureViewOwnedHandle();
        allocator.AddHandleToDispose(ownedViewHandle);

        dest.View = ownedViewHandle;
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