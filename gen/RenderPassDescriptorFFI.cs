using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
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
		this.NextInChain = default;
		this.Label = default;
		this.ColorAttachmentCount = default;
		this.ColorAttachments = default;
		this.DepthStencilAttachment = default;
		this.OcclusionQuerySet = default;
		this.TimestampWrites = default;
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
}

