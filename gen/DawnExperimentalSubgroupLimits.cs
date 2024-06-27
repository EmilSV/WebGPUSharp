using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnExperimentalSubgroupLimits
{
    public ChainedStructOut Chain;
    public uint MinSubgroupSize;
    public uint MaxSubgroupSize;

    public DawnExperimentalSubgroupLimits()
    {
    }


    public DawnExperimentalSubgroupLimits(ChainedStructOut chain = default, uint minSubgroupSize = default, uint maxSubgroupSize = default)
    {
        this.Chain = chain;
        this.MinSubgroupSize = minSubgroupSize;
        this.MaxSubgroupSize = maxSubgroupSize;
    }

}
