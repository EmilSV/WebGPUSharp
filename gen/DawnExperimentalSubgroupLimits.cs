using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnExperimentalSubgroupLimits
{
	public ChainedStructOut Chain;
	public uint MinSubgroupSize;
	public uint MaxSubgroupSize;

	public DawnExperimentalSubgroupLimits()
	{
		this.Chain = default;
		this.MinSubgroupSize = default;
		this.MaxSubgroupSize = default;
	}

	public DawnExperimentalSubgroupLimits(ChainedStructOut chain = default, uint minSubgroupSize = default, uint maxSubgroupSize = default)
	{
		this.Chain = chain;
		this.MinSubgroupSize = minSubgroupSize;
		this.MaxSubgroupSize = maxSubgroupSize;
	}
}

