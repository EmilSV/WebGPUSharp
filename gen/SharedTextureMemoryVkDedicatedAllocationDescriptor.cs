using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedTextureMemoryVkDedicatedAllocationDescriptor
{
	public ChainedStruct Chain;
	public WGPUBool DedicatedAllocation;

	public SharedTextureMemoryVkDedicatedAllocationDescriptor()
	{
		this.Chain = default;
		this.DedicatedAllocation = default;
	}

	public SharedTextureMemoryVkDedicatedAllocationDescriptor(ChainedStruct chain = default, WGPUBool dedicatedAllocation = default)
	{
		this.Chain = chain;
		this.DedicatedAllocation = dedicatedAllocation;
	}
}

