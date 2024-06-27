using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CommandBufferDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public CommandBufferDescriptorFFI()
    {
    }


    public CommandBufferDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public CommandBufferDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
