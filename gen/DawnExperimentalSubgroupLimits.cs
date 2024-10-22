using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnExperimentalSubgroupLimits
{
    public ChainedStructOut Chain;
    public uint MinSubgroupSize;
    public uint MaxSubgroupSize;

    public DawnExperimentalSubgroupLimits() { }

}
