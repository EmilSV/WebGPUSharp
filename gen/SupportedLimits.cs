using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SupportedLimits
{
    public ChainedStructOut* NextInChain;
    public Limits Limits;

    public SupportedLimits() { }

}
