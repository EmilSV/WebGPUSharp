using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ComputePipelineDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public PipelineLayoutHandle Layout;
	public ProgrammableStageDescriptorFFI Compute;

	public ComputePipelineDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Layout = default;
		this.Compute = default;
	}

	public ComputePipelineDescriptorFFI(byte* label = default, PipelineLayoutHandle layout = default, ProgrammableStageDescriptorFFI compute = default)
	{
		this.Label = label;
		this.Layout = layout;
		this.Compute = compute;
	}

	public ComputePipelineDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, PipelineLayoutHandle layout = default, ProgrammableStageDescriptorFFI compute = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.Layout = layout;
		this.Compute = compute;
	}
}

