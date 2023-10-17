using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnShaderModuleSPIRVOptionsDescriptor
{
	public ChainedStruct Chain;
	public WGPUBool AllowNonUniformDerivatives;

	public DawnShaderModuleSPIRVOptionsDescriptor()
	{
		this.Chain = default;
		this.AllowNonUniformDerivatives = default;
	}

	public DawnShaderModuleSPIRVOptionsDescriptor(ChainedStruct chain = default, WGPUBool allowNonUniformDerivatives = default)
	{
		this.Chain = chain;
		this.AllowNonUniformDerivatives = allowNonUniformDerivatives;
	}
}

