using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MultisampleState
{
	public ChainedStruct* NextInChain;
	public uint Count;
	public uint Mask;
	public WGPUBool AlphaToCoverageEnabled;

	public MultisampleState()
	{
		this.NextInChain = default;
		this.Count = default;
		this.Mask = default;
		this.AlphaToCoverageEnabled = default;
	}

	public MultisampleState(uint count = default, uint mask = default, WGPUBool alphaToCoverageEnabled = default)
	{
		this.Count = count;
		this.Mask = mask;
		this.AlphaToCoverageEnabled = alphaToCoverageEnabled;
	}

	public MultisampleState(ChainedStruct* nextInChain = default, uint count = default, uint mask = default, WGPUBool alphaToCoverageEnabled = default)
	{
		this.NextInChain = nextInChain;
		this.Count = count;
		this.Mask = mask;
		this.AlphaToCoverageEnabled = alphaToCoverageEnabled;
	}
}

