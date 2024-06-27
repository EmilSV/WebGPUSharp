using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SharedTextureMemoryDescriptorFFI()
    {
    }


    public SharedTextureMemoryDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public SharedTextureMemoryDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
