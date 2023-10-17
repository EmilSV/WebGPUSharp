using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ComputePassDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public nuint TimestampWriteCount;
	public ComputePassTimestampWriteFFI* TimestampWrites;

	public ComputePassDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.TimestampWriteCount = default;
		this.TimestampWrites = default;
	}

	public ComputePassDescriptorFFI(byte* label = default, nuint timestampWriteCount = default, ComputePassTimestampWriteFFI* timestampWrites = default)
	{
		this.Label = label;
		this.TimestampWriteCount = timestampWriteCount;
		this.TimestampWrites = timestampWrites;
	}

	public ComputePassDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint timestampWriteCount = default, ComputePassTimestampWriteFFI* timestampWrites = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.TimestampWriteCount = timestampWriteCount;
		this.TimestampWrites = timestampWrites;
	}
}

