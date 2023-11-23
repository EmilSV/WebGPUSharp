using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ComputePassDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public ComputePassTimestampWritesFFI* TimestampWrites;

	public ComputePassDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.TimestampWrites = default;
	}

	public ComputePassDescriptorFFI(byte* label = default, ComputePassTimestampWritesFFI* timestampWrites = default)
	{
		this.Label = label;
		this.TimestampWrites = timestampWrites;
	}

	public ComputePassDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, ComputePassTimestampWritesFFI* timestampWrites = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.TimestampWrites = timestampWrites;
	}
}

