using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnTextureInternalUsageDescriptor
{
	public ChainedStruct Chain;
	public TextureUsage InternalUsage;

	public DawnTextureInternalUsageDescriptor()
	{
		this.Chain = default;
		this.InternalUsage = default;
	}

	public DawnTextureInternalUsageDescriptor(ChainedStruct chain = default, TextureUsage internalUsage = default)
	{
		this.Chain = chain;
		this.InternalUsage = internalUsage;
	}
}

