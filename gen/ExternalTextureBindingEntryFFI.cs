using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public partial struct ExternalTextureBindingEntryFFI
{
	public ChainedStruct Chain;
	public ExternalTextureHandle ExternalTexture;

	public ExternalTextureBindingEntryFFI()
	{
		this.Chain = default;
		this.ExternalTexture = default;
	}

	public ExternalTextureBindingEntryFFI(ChainedStruct chain = default, ExternalTextureHandle externalTexture = default)
	{
		this.Chain = chain;
		this.ExternalTexture = externalTexture;
	}
}

