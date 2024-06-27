using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct ChainedStructOut
{
    public ChainedStructOut* Next;
    public SType SType;

    public ChainedStructOut()
    {
    }


    public ChainedStructOut(ChainedStructOut* next = default, SType sType = default)
    {
        this.Next = next;
        this.SType = sType;
    }

}
