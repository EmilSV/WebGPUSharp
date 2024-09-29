using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassDepthStencilAttachmentFFI
{
    /// <summary>
    /// A  <see cref="FFI.TextureView"/> describing the texture subresource that will be output to
    /// and read from for this depth/stencil attachment.
    /// </summary>
    public required TextureViewHandle View;
    /// <summary>
    /// Indicates the load operation to perform on  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>'s
    /// depth component prior to executing the render pass.
    /// Note: It is recommended to prefer clearing; see  <see cref="LoadOp."clear""/> for details.
    /// </summary>
    public LoadOp DepthLoadOp;
    /// <summary>
    /// The store operation to perform on  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>'s
    /// depth component after executing the render pass.
    /// </summary>
    public StoreOp DepthStoreOp;
    /// <summary>
    /// Indicates the value to clear  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>'s depth component
    /// to prior to executing the render pass. Ignored if  <see cref="FFI.RenderPassDepthStencilAttachment.DepthLoadOp"/>
    /// is not  <see cref="LoadOp."clear""/>. Must be between 0.0 and 1.0, inclusive.
    /// 
    /// </summary>
    public float DepthClearValue;
    /// <summary>
    /// Indicates that the depth component of  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>
    /// is read only.
    /// </summary>
    public WebGPUBool DepthReadOnly = false;
    /// <summary>
    /// Indicates the load operation to perform on  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>'s
    /// stencil component prior to executing the render pass.
    /// Note: It is recommended to prefer clearing; see  <see cref="LoadOp."clear""/> for details.
    /// </summary>
    public LoadOp StencilLoadOp;
    /// <summary>
    /// The store operation to perform on  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>'s
    /// stencil component after executing the render pass.
    /// </summary>
    public StoreOp StencilStoreOp;
    /// <summary>
    /// Indicates the value to clear  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>'s stencil component
    /// to prior to executing the render pass. Ignored if  <see cref="FFI.RenderPassDepthStencilAttachment.StencilLoadOp"/>
    /// is not  <see cref="LoadOp."clear""/>.
    /// The value will be converted to the type of the stencil aspect of |view| by taking the same
    /// number of LSBs as the number of bits in the stencil aspect of one texel of |view|.
    /// </summary>
    public uint StencilClearValue = 0;
    /// <summary>
    /// Indicates that the stencil component of  <see cref="FFI.RenderPassDepthStencilAttachment.View"/>
    /// is read only.
    /// </summary>
    public WebGPUBool StencilReadOnly = false;

    public RenderPassDepthStencilAttachmentFFI()
    {
    }

}
