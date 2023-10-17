using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RequiredLimits
{
	public ChainedStruct* NextInChain;
	public Limits Limits;

	public RequiredLimits()
	{
		this.NextInChain = default;
		this.Limits = default;
	}

	public RequiredLimits(Limits limits = default)
	{
		this.Limits = limits;
	}

	public RequiredLimits(ChainedStruct* nextInChain = default, Limits limits = default)
	{
		this.NextInChain = nextInChain;
		this.Limits = limits;
	}
}

