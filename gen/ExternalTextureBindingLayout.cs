using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct ExternalTextureBindingLayout
{
	public ChainedStruct Chain;

	public ExternalTextureBindingLayout()
	{
		this.Chain = default;
	}

	public ExternalTextureBindingLayout(ChainedStruct chain = default)
	{
		this.Chain = chain;
	}
}

