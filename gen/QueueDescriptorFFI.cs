using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QueueDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public QueueDescriptorFFI()
    {
    }


    public QueueDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public QueueDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
