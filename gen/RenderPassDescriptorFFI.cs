using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint ColorAttachmentCount;
    /// <summary>
    /// The set of  <see cref="FFI.RenderPassColorAttachment"/> values in this sequence defines which
    /// color attachments will be output to when executing this render pass.
    /// Due to usage compatibility, no color attachment
    /// may alias another attachment or any resource used inside the render pass.
    /// </summary>
    public required RenderPassColorAttachmentFFI* ColorAttachments;
    /// <summary>
    /// The  <see cref="FFI.RenderPassDepthStencilAttachment"/> value that defines the depth/stencil
    /// attachment that will be output to and tested against when executing this render pass.
    /// Due to usage compatibility, no writable depth/stencil attachment
    /// may alias another attachment or any resource used inside the render pass.
    /// </summary>
    public RenderPassDepthStencilAttachmentFFI* DepthStencilAttachment;
    /// <summary>
    /// The  <see cref="FFI.QuerySet"/> value defines where the occlusion query results will be stored for this pass.
    /// </summary>
    public QuerySetHandle OcclusionQuerySet;
    /// <summary>
    /// Defines which timestamp values will be written for this pass, and where to write them to.
    /// </summary>
    public RenderPassTimestampWritesFFI* TimestampWrites;

    public RenderPassDescriptorFFI()
    {
    }

}
