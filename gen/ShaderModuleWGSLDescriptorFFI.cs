using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ShaderModuleWGSLDescriptorFFI
{
	public ChainedStruct Chain;
	public byte* Code;

	public ShaderModuleWGSLDescriptorFFI()
	{
		this.Chain = default;
		this.Code = default;
	}

	public ShaderModuleWGSLDescriptorFFI(ChainedStruct chain = default, byte* code = default)
	{
		this.Chain = chain;
		this.Code = code;
	}
}

