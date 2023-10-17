using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ShaderModuleDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public ShaderModuleDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public ShaderModuleDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public ShaderModuleDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

