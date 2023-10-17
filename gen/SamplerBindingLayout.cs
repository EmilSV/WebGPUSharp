using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SamplerBindingLayout
{
	public ChainedStruct* NextInChain;
	public SamplerBindingType Type;

	public SamplerBindingLayout()
	{
		this.NextInChain = default;
		this.Type = default;
	}

	public SamplerBindingLayout(SamplerBindingType type = default)
	{
		this.Type = type;
	}

	public SamplerBindingLayout(ChainedStruct* nextInChain = default, SamplerBindingType type = default)
	{
		this.NextInChain = nextInChain;
		this.Type = type;
	}
}

