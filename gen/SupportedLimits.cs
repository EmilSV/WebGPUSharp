using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SupportedLimits
{
    public ChainedStructOut* NextInChain;
    public Limits Limits;

    public SupportedLimits()
    {
    }


    public SupportedLimits(ChainedStructOut* nextInChain = default, Limits limits = default)
    {
        this.NextInChain = nextInChain;
        this.Limits = limits;
    }


    public SupportedLimits(Limits limits = default)
    {
        this.Limits = limits;
    }

}
