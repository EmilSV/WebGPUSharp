using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SharedFenceDescriptorFFI()
    {
    }


    public SharedFenceDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public SharedFenceDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
