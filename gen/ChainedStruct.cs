using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct ChainedStruct
{
    public ChainedStruct* Next;
    public SType SType;

    public ChainedStruct() { }

}
