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

}
