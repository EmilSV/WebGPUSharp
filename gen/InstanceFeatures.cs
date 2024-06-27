using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct InstanceFeatures
{
    public ChainedStruct* NextInChain;
    public WebGPUBool TimedWaitAnyEnable;
    public nuint TimedWaitAnyMaxCount;

    public InstanceFeatures()
    {
    }


    public InstanceFeatures(ChainedStruct* nextInChain = default, WebGPUBool timedWaitAnyEnable = default, nuint timedWaitAnyMaxCount = default)
    {
        this.NextInChain = nextInChain;
        this.TimedWaitAnyEnable = timedWaitAnyEnable;
        this.TimedWaitAnyMaxCount = timedWaitAnyMaxCount;
    }


    public InstanceFeatures(WebGPUBool timedWaitAnyEnable = default, nuint timedWaitAnyMaxCount = default)
    {
        this.TimedWaitAnyEnable = timedWaitAnyEnable;
        this.TimedWaitAnyMaxCount = timedWaitAnyMaxCount;
    }

}
