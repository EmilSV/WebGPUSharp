using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedTextureMemoryVkImageLayoutEndState
{
	public ChainedStructOut Chain;
	public int OldLayout;
	public int NewLayout;

	public SharedTextureMemoryVkImageLayoutEndState()
	{
		this.Chain = default;
		this.OldLayout = default;
		this.NewLayout = default;
	}

	public SharedTextureMemoryVkImageLayoutEndState(ChainedStructOut chain = default, int oldLayout = default, int newLayout = default)
	{
		this.Chain = chain;
		this.OldLayout = oldLayout;
		this.NewLayout = newLayout;
	}
}

