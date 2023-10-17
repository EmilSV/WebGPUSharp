using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryEndAccessStateFFI
{
	public ChainedStructOut* NextInChain;
	public WGPUBool Initialized;
	public nuint FenceCount;
	public SharedFenceHandle* Fences;
	public ulong* SignaledValues;

	public SharedTextureMemoryEndAccessStateFFI()
	{
		this.NextInChain = default;
		this.Initialized = default;
		this.FenceCount = default;
		this.Fences = default;
		this.SignaledValues = default;
	}

	public SharedTextureMemoryEndAccessStateFFI(ChainedStructOut* nextInChain = default, WGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
	{
		this.NextInChain = nextInChain;
		this.Initialized = initialized;
		this.FenceCount = fenceCount;
		this.Fences = fences;
		this.SignaledValues = signaledValues;
	}
}

