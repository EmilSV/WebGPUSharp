using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct InstanceDescriptor
{
	public ChainedStruct* NextInChain;

	public InstanceDescriptor()
	{
		this.NextInChain = default;
	}

	public InstanceDescriptor(ChainedStruct* nextInChain = default)
	{
		this.NextInChain = nextInChain;
	}
}

