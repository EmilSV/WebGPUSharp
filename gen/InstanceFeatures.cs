using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct InstanceFeatures
{
    public ChainedStruct* NextInChain;
    public WebGPUBool TimedWaitAnyEnable;
    public nuint TimedWaitAnyMaxCount;

    public InstanceFeatures() { }

}
