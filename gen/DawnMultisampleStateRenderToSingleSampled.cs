using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnMultisampleStateRenderToSingleSampled
{
	public ChainedStruct Chain;
	public WGPUBool Enabled;

	public DawnMultisampleStateRenderToSingleSampled()
	{
		this.Chain = default;
		this.Enabled = default;
	}

	public DawnMultisampleStateRenderToSingleSampled(ChainedStruct chain = default, WGPUBool enabled = default)
	{
		this.Chain = chain;
		this.Enabled = enabled;
	}
}

