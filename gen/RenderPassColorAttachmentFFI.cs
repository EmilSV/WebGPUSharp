using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassColorAttachmentFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A  <see cref="WebGpuSharp.TextureView"/> describing the texture subresource that will be output to for this
    /// color attachment.
    /// </summary>
    public required TextureViewHandle View;
    /// <summary>
    /// Indicates the depth slice index of  <see cref="TextureViewDimension.D3"/>  <see cref="WebGpuSharp.RenderPassColorAttachment.View"/>
    /// that will be output to for this color attachment.
    /// </summary>
    public uint DepthSlice;
    /// <summary>
    /// A  <see cref="WebGpuSharp.TextureView"/> describing the texture subresource that will receive the resolved
    /// output for this color attachment if  <see cref="WebGpuSharp.RenderPassColorAttachment.View"/> is
    /// multisampled.
    /// </summary>
    public TextureViewHandle ResolveTarget;
    /// <summary>
    /// Indicates the load operation to perform on  <see cref="WebGpuSharp.RenderPassColorAttachment.View"/> prior to
    /// executing the render pass.
    /// Note: It is recommended to prefer clearing; see  <see cref="LoadOp.Clear"/> for details.
    /// </summary>
    public required LoadOp LoadOp;
    /// <summary>
    /// The store operation to perform on  <see cref="WebGpuSharp.RenderPassColorAttachment.View"/>
    /// after executing the render pass.
    /// </summary>
    public required StoreOp StoreOp;
    /// <summary>
    /// Indicates the value to clear  <see cref="WebGpuSharp.RenderPassColorAttachment.View"/> to prior to executing the
    /// render pass. If not provided, defaults to `{r: 0, g: 0, b: 0, a: 0}`. Ignored
    /// if  <see cref="WebGpuSharp.RenderPassColorAttachment.LoadOp"/> is not  <see cref="LoadOp.Clear"/>.
    /// The components of  <see cref="WebGpuSharp.RenderPassColorAttachment.ClearValue"/> are all double values.
    /// They are converted to a texel value of texture format matching the render attachment.
    /// If conversion fails, a validation error is generated.
    /// </summary>
    public Color ClearValue;

    public RenderPassColorAttachmentFFI() { }

}
