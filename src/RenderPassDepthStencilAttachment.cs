using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
namespace WebGpuSharp;

/// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI"/>
public struct RenderPassDepthStencilAttachment :
     IWebGpuFFIConvertibleAlloc<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>
{
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.View"/>
    public required TextureViewBase View;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.DepthLoadOp"/>
    public LoadOp DepthLoadOp;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.DepthStoreOp"/>
    public StoreOp DepthStoreOp;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.DepthClearValue"/>
    public float DepthClearValue;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.DepthReadOnly"/>
    public bool DepthReadOnly = false;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.StencilLoadOp"/>
    public LoadOp StencilLoadOp;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.StencilStoreOp"/>
    public StoreOp StencilStoreOp;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.StencilClearValue/>
    public uint StencilClearValue = 0;
    /// <inheritdoc cref="RenderPassDepthStencilAttachmentFFI.StencilReadOnly"/>
    public bool StencilReadOnly = false;

    public RenderPassDepthStencilAttachment()
    {
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassDepthStencilAttachment, RenderPassDepthStencilAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassDepthStencilAttachment input, WebGpuAllocatorHandle allocator, out RenderPassDepthStencilAttachmentFFI dest)
    {
        dest = default;
        dest.View = allocator.GetHandle(input.View);
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