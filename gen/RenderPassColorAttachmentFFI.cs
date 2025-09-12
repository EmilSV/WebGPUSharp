using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a color attachment to a <see cref="FFI.RenderPassHandle" />.
/// 
/// For use with <see cref="RenderPassDescriptorFFI" />.
/// </summary>
public unsafe partial struct RenderPassColorAttachmentFFI
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
    /// Describes the texture subresource that will be output to for this color attachment.
    /// The subresource is determined by calling get as texture view( <see cref="RenderPassColorAttachment.View"/>).
    /// </summary>
    public required TextureViewHandle View;
    /// <summary>
    /// Indicates the depth slice index of  <see cref="TextureViewDimension.D3"/>  <see cref="RenderPassColorAttachment.View"/>
    /// that will be output to for this color attachment.
    /// </summary>
    public uint DepthSlice = WebGPU_FFI.DEPTH_SLICE_UNDEFINED;
    /// <summary>
    /// Describes the texture subresource that will receive the resolved output for this color
    /// attachment if  <see cref="RenderPassColorAttachment.View"/> is multisampled.
    /// The subresource is determined by calling get as texture view( <see cref="RenderPassColorAttachment.ResolveTarget"/>).
    /// </summary>
    public TextureViewHandle ResolveTarget;
    /// <summary>
    /// Indicates the load operation to perform on  <see cref="RenderPassColorAttachment.View"/> prior to
    /// executing the render pass.
    /// Note: It is recommended to prefer clearing; see  <see cref="LoadOp.Clear"/> for details.
    /// </summary>
    public required LoadOp LoadOp;
    /// <summary>
    /// The store operation to perform on  <see cref="RenderPassColorAttachment.View"/>
    /// after executing the render pass.
    /// </summary>
    public required StoreOp StoreOp;
    /// <summary>
    /// Indicates the value to clear  <see cref="RenderPassColorAttachment.View"/> to prior to executing the
    /// render pass. If not provided, defaults to `{r: 0, g: 0, b: 0, a: 0}`. Ignored
    /// if  <see cref="RenderPassColorAttachment.LoadOp"/> is not  <see cref="LoadOp.Clear"/>.
    /// The components of  <see cref="RenderPassColorAttachment.ClearValue"/> are all double values.
    /// They are converted to a texel value of texture format matching the render attachment.
    /// If conversion fails, a validation error is generated.
    /// </summary>
    public Color ClearValue;

    public RenderPassColorAttachmentFFI() { }

}
