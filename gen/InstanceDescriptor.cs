using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct InstanceDescriptor
{
	public ChainedStruct* NextInChain;
	public InstanceFeatures Features;

	public InstanceDescriptor()
	{
		this.NextInChain = default;
		this.Features = default;
	}

	public InstanceDescriptor(InstanceFeatures features = default)
	{
		this.Features = features;
	}

	public InstanceDescriptor(ChainedStruct* nextInChain = default, InstanceFeatures features = default)
	{
		this.NextInChain = nextInChain;
		this.Features = features;
	}
}

