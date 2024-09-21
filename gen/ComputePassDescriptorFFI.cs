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

}
