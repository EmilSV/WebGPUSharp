using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint ColorAttachmentCount;
    public RenderPassColorAttachmentFFI* ColorAttachments;
    public RenderPassDepthStencilAttachmentFFI* DepthStencilAttachment;
    public QuerySetHandle OcclusionQuerySet;
    public RenderPassTimestampWritesFFI* TimestampWrites;

    public RenderPassDescriptorFFI()
    {
    }


    public RenderPassDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint colorAttachmentCount = default, RenderPassColorAttachmentFFI* colorAttachments = default, RenderPassDepthStencilAttachmentFFI* depthStencilAttachment = default, QuerySetHandle occlusionQuerySet = default, RenderPassTimestampWritesFFI* timestampWrites = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.ColorAttachmentCount = colorAttachmentCount;
        this.ColorAttachments = colorAttachments;
        this.DepthStencilAttachment = depthStencilAttachment;
        this.OcclusionQuerySet = occlusionQuerySet;
        this.TimestampWrites = timestampWrites;
    }


    public RenderPassDescriptorFFI(byte* label = default, nuint colorAttachmentCount = default, RenderPassColorAttachmentFFI* colorAttachments = default, RenderPassDepthStencilAttachmentFFI* depthStencilAttachment = default, QuerySetHandle occlusionQuerySet = default, RenderPassTimestampWritesFFI* timestampWrites = default)
    {
        this.Label = label;
        this.ColorAttachmentCount = colorAttachmentCount;
        this.ColorAttachments = colorAttachments;
        this.DepthStencilAttachment = depthStencilAttachment;
        this.OcclusionQuerySet = occlusionQuerySet;
        this.TimestampWrites = timestampWrites;
    }

}
