using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct InstanceDescriptor
{
    public ChainedStruct* NextInChain;
    public InstanceFeatures Features;

    public InstanceDescriptor()
    {
    }


    public InstanceDescriptor(ChainedStruct* nextInChain = default, InstanceFeatures features = default)
    {
        this.NextInChain = nextInChain;
        this.Features = features;
    }


    public InstanceDescriptor(InstanceFeatures features = default)
    {
        this.Features = features;
    }

}
