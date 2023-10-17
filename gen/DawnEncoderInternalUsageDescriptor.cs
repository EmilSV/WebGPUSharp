using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnEncoderInternalUsageDescriptor
{
	public ChainedStruct Chain;
	public WGPUBool UseInternalUsages;

	public DawnEncoderInternalUsageDescriptor()
	{
		this.Chain = default;
		this.UseInternalUsages = default;
	}

	public DawnEncoderInternalUsageDescriptor(ChainedStruct chain = default, WGPUBool useInternalUsages = default)
	{
		this.Chain = chain;
		this.UseInternalUsages = useInternalUsages;
	}
}

