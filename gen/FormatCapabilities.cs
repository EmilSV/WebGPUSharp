using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct FormatCapabilities
{
    public ChainedStructOut* NextInChain;

    public FormatCapabilities()
    {
    }


    public FormatCapabilities(ChainedStructOut* nextInChain = default)
    {
        this.NextInChain = nextInChain;
    }

}
