using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CommandEncoderDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public CommandEncoderDescriptorFFI()
    {
    }


    public CommandEncoderDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public CommandEncoderDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
