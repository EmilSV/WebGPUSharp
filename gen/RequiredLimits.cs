using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct RequiredLimits
{
    public ChainedStruct* NextInChain;
    public Limits Limits;

    public RequiredLimits()
    {
    }


    public RequiredLimits(ChainedStruct* nextInChain = default, Limits limits = default)
    {
        this.NextInChain = nextInChain;
        this.Limits = limits;
    }


    public RequiredLimits(Limits limits = default)
    {
        this.Limits = limits;
    }

}
