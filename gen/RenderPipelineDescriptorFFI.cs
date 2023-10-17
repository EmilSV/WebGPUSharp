using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RenderPipelineDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public PipelineLayoutHandle Layout;
	public VertexStateFFI Vertex;
	public PrimitiveState Primitive;
	public DepthStencilState* DepthStencil;
	public MultisampleState Multisample;
	public FragmentStateFFI* Fragment;

	public RenderPipelineDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Layout = default;
		this.Vertex = default;
		this.Primitive = default;
		this.DepthStencil = default;
		this.Multisample = default;
		this.Fragment = default;
	}

	public RenderPipelineDescriptorFFI(byte* label = default, PipelineLayoutHandle layout = default, VertexStateFFI vertex = default, PrimitiveState primitive = default, DepthStencilState* depthStencil = default, MultisampleState multisample = default, FragmentStateFFI* fragment = default)
	{
		this.Label = label;
		this.Layout = layout;
		this.Vertex = vertex;
		this.Primitive = primitive;
		this.DepthStencil = depthStencil;
		this.Multisample = multisample;
		this.Fragment = fragment;
	}

	public RenderPipelineDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, PipelineLayoutHandle layout = default, VertexStateFFI vertex = default, PrimitiveState primitive = default, DepthStencilState* depthStencil = default, MultisampleState multisample = default, FragmentStateFFI* fragment = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.Layout = layout;
		this.Vertex = vertex;
		this.Primitive = primitive;
		this.DepthStencil = depthStencil;
		this.Multisample = multisample;
		this.Fragment = fragment;
	}
}

