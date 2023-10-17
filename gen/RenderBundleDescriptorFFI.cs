using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RenderBundleDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public RenderBundleDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public RenderBundleDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public RenderBundleDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

