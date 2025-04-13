using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a depth/stencil attachment to a render pass.
/// </summary>
public unsafe partial struct RenderPassDepthStencilAttachmentFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A  <see cref="TextureView"/> describing the texture subresource that will be output to
    /// and read from for this depth/stencil attachment.
    /// </summary>
    public required TextureViewHandle View;
    /// <summary>
    /// Indicates the load operation to perform on  <see cref="RenderPassDepthStencilAttachment.View"/>'s
    /// depth component prior to executing the render pass.
    /// Note: It is recommended to prefer clearing; see  <see cref="LoadOp.Clear"/> for details.
    /// </summary>
    public LoadOp DepthLoadOp;
    /// <summary>
    /// The store operation to perform on  <see cref="RenderPassDepthStencilAttachment.View"/>'s
    /// depth component after executing the render pass.
    /// </summary>
    public StoreOp DepthStoreOp;
    /// <summary>
    /// Indicates the value to clear  <see cref="RenderPassDepthStencilAttachment.View"/>'s depth component
    /// to prior to executing the render pass. Ignored if  <see cref="RenderPassDepthStencilAttachment.DepthLoadOp"/>
    /// is not  <see cref="LoadOp.Clear"/>. Must be between 0.0 and 1.0, inclusive.
    /// 
    /// </summary>
    public float DepthClearValue;
    /// <summary>
    /// Indicates that the depth component of  <see cref="RenderPassDepthStencilAttachment.View"/>
    /// is read only.
    /// </summary>
    public WebGPUBool DepthReadOnly = false;
    /// <summary>
    /// Indicates the load operation to perform on  <see cref="RenderPassDepthStencilAttachment.View"/>'s
    /// stencil component prior to executing the render pass.
    /// Note: It is recommended to prefer clearing; see  <see cref="LoadOp.Clear"/> for details.
    /// </summary>
    public LoadOp StencilLoadOp;
    /// <summary>
    /// The store operation to perform on  <see cref="RenderPassDepthStencilAttachment.View"/>'s
    /// stencil component after executing the render pass.
    /// </summary>
    public StoreOp StencilStoreOp;
    /// <summary>
    /// Indicates the value to clear  <see cref="RenderPassDepthStencilAttachment.View"/>'s stencil component
    /// to prior to executing the render pass. Ignored if  <see cref="RenderPassDepthStencilAttachment.StencilLoadOp"/>
    /// is not  <see cref="LoadOp.Clear"/>.
    /// The value will be converted to the type of the stencil aspect of view by taking the same
    /// number of LSBs as the number of bits in the stencil aspect of one texel of view.
    /// </summary>
    public uint StencilClearValue = 0;
    /// <summary>
    /// Indicates that the stencil component of  <see cref="RenderPassDepthStencilAttachment.View"/>
    /// is read only.
    /// </summary>
    public WebGPUBool StencilReadOnly = false;

    public RenderPassDepthStencilAttachmentFFI() { }

}
