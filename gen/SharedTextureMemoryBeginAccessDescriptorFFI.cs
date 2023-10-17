using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryBeginAccessDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public WGPUBool Initialized;
	public nuint FenceCount;
	public SharedFenceHandle* Fences;
	public ulong* SignaledValues;

	public SharedTextureMemoryBeginAccessDescriptorFFI()
	{
		this.NextInChain = default;
		this.Initialized = default;
		this.FenceCount = default;
		this.Fences = default;
		this.SignaledValues = default;
	}

	public SharedTextureMemoryBeginAccessDescriptorFFI(WGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
	{
		this.Initialized = initialized;
		this.FenceCount = fenceCount;
		this.Fences = fences;
		this.SignaledValues = signaledValues;
	}

	public SharedTextureMemoryBeginAccessDescriptorFFI(ChainedStruct* nextInChain = default, WGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
	{
		this.NextInChain = nextInChain;
		this.Initialized = initialized;
		this.FenceCount = fenceCount;
		this.Fences = fences;
		this.SignaledValues = signaledValues;
	}
}

