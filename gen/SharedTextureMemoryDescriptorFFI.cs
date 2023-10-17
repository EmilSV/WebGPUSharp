using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public SharedTextureMemoryDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public SharedTextureMemoryDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public SharedTextureMemoryDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

