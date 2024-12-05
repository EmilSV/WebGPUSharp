using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkDedicatedAllocationDescriptor
{
    public ChainedStruct Chain;
    public WebGPUBool DedicatedAllocation = new();

    public SharedTextureMemoryVkDedicatedAllocationDescriptor() { }

}
