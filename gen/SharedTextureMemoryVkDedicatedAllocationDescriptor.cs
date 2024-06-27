using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkDedicatedAllocationDescriptor
{
    public ChainedStruct Chain;
    public WebGPUBool DedicatedAllocation;

    public SharedTextureMemoryVkDedicatedAllocationDescriptor()
    {
    }


    public SharedTextureMemoryVkDedicatedAllocationDescriptor(ChainedStruct chain = default, WebGPUBool dedicatedAllocation = default)
    {
        this.Chain = chain;
        this.DedicatedAllocation = dedicatedAllocation;
    }

}
