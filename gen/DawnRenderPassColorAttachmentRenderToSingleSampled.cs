using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnRenderPassColorAttachmentRenderToSingleSampled
{
	public ChainedStruct Chain;
	public uint ImplicitSampleCount;

	public DawnRenderPassColorAttachmentRenderToSingleSampled()
	{
		this.Chain = default;
		this.ImplicitSampleCount = default;
	}

	public DawnRenderPassColorAttachmentRenderToSingleSampled(ChainedStruct chain = default, uint implicitSampleCount = default)
	{
		this.Chain = chain;
		this.ImplicitSampleCount = implicitSampleCount;
	}
}

