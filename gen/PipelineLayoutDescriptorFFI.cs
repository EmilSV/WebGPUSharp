using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct PipelineLayoutDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public nuint BindGroupLayoutCount;
	public BindGroupLayoutHandle* BindGroupLayouts;

	public PipelineLayoutDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.BindGroupLayoutCount = default;
		this.BindGroupLayouts = default;
	}

	public PipelineLayoutDescriptorFFI(byte* label = default, nuint bindGroupLayoutCount = default, BindGroupLayoutHandle* bindGroupLayouts = default)
	{
		this.Label = label;
		this.BindGroupLayoutCount = bindGroupLayoutCount;
		this.BindGroupLayouts = bindGroupLayouts;
	}

	public PipelineLayoutDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint bindGroupLayoutCount = default, BindGroupLayoutHandle* bindGroupLayouts = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.BindGroupLayoutCount = bindGroupLayoutCount;
		this.BindGroupLayouts = bindGroupLayouts;
	}
}

