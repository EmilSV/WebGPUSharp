using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedTextureMemoryVkImageLayoutBeginState
{
	public ChainedStruct Chain;
	public int OldLayout;
	public int NewLayout;

	public SharedTextureMemoryVkImageLayoutBeginState()
	{
		this.Chain = default;
		this.OldLayout = default;
		this.NewLayout = default;
	}

	public SharedTextureMemoryVkImageLayoutBeginState(ChainedStruct chain = default, int oldLayout = default, int newLayout = default)
	{
		this.Chain = chain;
		this.OldLayout = oldLayout;
		this.NewLayout = newLayout;
	}
}

