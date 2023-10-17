using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CommandEncoderDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public CommandEncoderDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public CommandEncoderDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public CommandEncoderDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

