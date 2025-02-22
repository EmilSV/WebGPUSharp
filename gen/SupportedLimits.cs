using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SupportedLimits
{
    public ChainedStruct* NextInChain;
    public Limits Limits = new();

    public SupportedLimits() { }

}
