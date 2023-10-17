using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedFenceDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public SharedFenceDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public SharedFenceDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public SharedFenceDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

