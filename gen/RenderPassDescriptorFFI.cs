using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint ColorAttachmentCount;
    public required RenderPassColorAttachmentFFI* ColorAttachments;
    public RenderPassDepthStencilAttachmentFFI* DepthStencilAttachment;
    public QuerySetHandle OcclusionQuerySet;
    public RenderPassTimestampWritesFFI* TimestampWrites;

    public RenderPassDescriptorFFI()
    {
    }

}
