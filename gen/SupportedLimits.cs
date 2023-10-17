using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SupportedLimits
{
	public ChainedStructOut* NextInChain;
	public Limits Limits;

	public SupportedLimits()
	{
		this.NextInChain = default;
		this.Limits = default;
	}

	public SupportedLimits(ChainedStructOut* nextInChain = default, Limits limits = default)
	{
		this.NextInChain = nextInChain;
		this.Limits = limits;
	}
}

