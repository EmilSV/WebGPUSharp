using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct RenderPassDescriptorMaxDrawCount
{
	public ChainedStruct Chain;
	public ulong MaxDrawCount;

	public RenderPassDescriptorMaxDrawCount()
	{
		this.Chain = default;
		this.MaxDrawCount = default;
	}

	public RenderPassDescriptorMaxDrawCount(ChainedStruct chain = default, ulong maxDrawCount = default)
	{
		this.Chain = chain;
		this.MaxDrawCount = maxDrawCount;
	}
}

