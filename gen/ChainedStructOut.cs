using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct ChainedStructOut
{
    public ChainedStructOut* Next;
    public SType SType;

    public ChainedStructOut() { }

}
