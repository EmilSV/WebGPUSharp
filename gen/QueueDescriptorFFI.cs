using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct QueueDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public QueueDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public QueueDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public QueueDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

