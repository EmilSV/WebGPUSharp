using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct InstanceDescriptor
{
    public ChainedStruct* NextInChain;
    public InstanceFeatures Features = new();

    public InstanceDescriptor() { }

}
