using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ConstantEntryFFI
{
	public ChainedStruct* NextInChain;
	public byte* Key;
	public double Value;

	public ConstantEntryFFI()
	{
		this.NextInChain = default;
		this.Key = default;
		this.Value = default;
	}

	public ConstantEntryFFI(byte* key = default, double value = default)
	{
		this.Key = key;
		this.Value = value;
	}

	public ConstantEntryFFI(ChainedStruct* nextInChain = default, byte* key = default, double value = default)
	{
		this.NextInChain = nextInChain;
		this.Key = key;
		this.Value = value;
	}
}

