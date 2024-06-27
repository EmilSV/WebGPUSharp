using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePassDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public ComputePassTimestampWritesFFI* TimestampWrites;

    public ComputePassDescriptorFFI()
    {
    }


    public ComputePassDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, ComputePassTimestampWritesFFI* timestampWrites = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.TimestampWrites = timestampWrites;
    }


    public ComputePassDescriptorFFI(byte* label = default, ComputePassTimestampWritesFFI* timestampWrites = default)
    {
        this.Label = label;
        this.TimestampWrites = timestampWrites;
    }

}
