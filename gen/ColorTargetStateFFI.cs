using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ColorTargetStateFFI
{
	public ChainedStruct* NextInChain;
	public TextureFormat Format;
	public BlendState* Blend;
	public ColorWriteMask WriteMask;

	public ColorTargetStateFFI()
	{
		this.NextInChain = default;
		this.Format = default;
		this.Blend = default;
		this.WriteMask = default;
	}

	public ColorTargetStateFFI(TextureFormat format = default, BlendState* blend = default, ColorWriteMask writeMask = default)
	{
		this.Format = format;
		this.Blend = blend;
		this.WriteMask = writeMask;
	}

	public ColorTargetStateFFI(ChainedStruct* nextInChain = default, TextureFormat format = default, BlendState* blend = default, ColorWriteMask writeMask = default)
	{
		this.NextInChain = nextInChain;
		this.Format = format;
		this.Blend = blend;
		this.WriteMask = writeMask;
	}
}

