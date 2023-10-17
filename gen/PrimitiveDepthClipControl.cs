using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct PrimitiveDepthClipControl
{
	public ChainedStruct Chain;
	public WGPUBool UnclippedDepth;

	public PrimitiveDepthClipControl()
	{
		this.Chain = default;
		this.UnclippedDepth = default;
	}

	public PrimitiveDepthClipControl(ChainedStruct chain = default, WGPUBool unclippedDepth = default)
	{
		this.Chain = chain;
		this.UnclippedDepth = unclippedDepth;
	}
}

