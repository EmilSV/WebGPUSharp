using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct PrimitiveState
{
	public ChainedStruct* NextInChain;
	public PrimitiveTopology Topology;
	public IndexFormat StripIndexFormat;
	public FrontFace FrontFace;
	public CullMode CullMode;

	public PrimitiveState()
	{
		this.NextInChain = default;
		this.Topology = default;
		this.StripIndexFormat = default;
		this.FrontFace = default;
		this.CullMode = default;
	}

	public PrimitiveState(PrimitiveTopology topology = default, IndexFormat stripIndexFormat = default, FrontFace frontFace = default, CullMode cullMode = default)
	{
		this.Topology = topology;
		this.StripIndexFormat = stripIndexFormat;
		this.FrontFace = frontFace;
		this.CullMode = cullMode;
	}

	public PrimitiveState(ChainedStruct* nextInChain = default, PrimitiveTopology topology = default, IndexFormat stripIndexFormat = default, FrontFace frontFace = default, CullMode cullMode = default)
	{
		this.NextInChain = nextInChain;
		this.Topology = topology;
		this.StripIndexFormat = stripIndexFormat;
		this.FrontFace = frontFace;
		this.CullMode = cullMode;
	}
}

