using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;

	public SurfaceDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
	}

	public SurfaceDescriptorFFI(byte* label = default)
	{
		this.Label = label;
	}

	public SurfaceDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
	}
}

