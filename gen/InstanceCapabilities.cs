using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct InstanceCapabilities
{
    public ChainedStruct* NextInChain;
    public WebGPUBool TimedWaitAnyEnable = new();
    public nuint TimedWaitAnyMaxCount;

    public InstanceCapabilities() { }

}
