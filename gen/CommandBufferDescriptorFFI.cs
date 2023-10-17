using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CommandBufferDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public CommandBufferDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public CommandBufferDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public CommandBufferDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

