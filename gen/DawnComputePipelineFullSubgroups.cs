using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnComputePipelineFullSubgroups
{
    public ChainedStruct Chain;
    public WebGPUBool RequiresFullSubgroups;

    public DawnComputePipelineFullSubgroups()
    {
    }


    public DawnComputePipelineFullSubgroups(ChainedStruct chain = default, WebGPUBool requiresFullSubgroups = default)
    {
        this.Chain = chain;
        this.RequiresFullSubgroups = requiresFullSubgroups;
    }

}
