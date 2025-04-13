using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the attachments of a render pass.
/// 
/// For use with <see cref="CommandEncoderHandle.BeginRenderPass" />.
/// </summary>
public unsafe partial struct RenderPassDescriptorFFI
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
    /// A label to apply to the render pass.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// the number of color attachments in the colorAttachments sequence.
    /// </summary>
    public nuint ColorAttachmentCount;
    /// <summary>
    /// The set of  <see cref="RenderPassColorAttachment"/> values in this sequence defines which
    /// color attachments will be output to when executing this render pass.
    /// Due to usage compatibility, no color attachment
    /// may alias another attachment or any resource used inside the render pass.
    /// </summary>
    public required RenderPassColorAttachmentFFI* ColorAttachments;
    /// <summary>
    /// The  <see cref="RenderPassDepthStencilAttachment"/> value that defines the depth/stencil
    /// attachment that will be output to and tested against when executing this render pass.
    /// Due to usage compatibility, no writable depth/stencil attachment
    /// may alias another attachment or any resource used inside the render pass.
    /// </summary>
    public RenderPassDepthStencilAttachmentFFI* DepthStencilAttachment;
    /// <summary>
    /// The  <see cref="QuerySet"/> value defines where the occlusion query results will be stored for this pass.
    /// </summary>
    public QuerySetHandle OcclusionQuerySet;
    /// <summary>
    /// Defines which timestamp values will be written for this pass, and where to write them to.
    /// </summary>
    public PassTimestampWritesFFI* TimestampWrites;

    public RenderPassDescriptorFFI() { }

}
