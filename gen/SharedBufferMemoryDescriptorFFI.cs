using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedBufferMemoryDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SharedBufferMemoryDescriptorFFI()
    {
    }


    public SharedBufferMemoryDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public SharedBufferMemoryDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
