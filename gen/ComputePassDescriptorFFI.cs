using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePassDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label;
    /// <summary>
    /// Defines which timestamp values will be written for this pass, and where to write them to.
    /// </summary>
    public ComputePassTimestampWritesFFI* TimestampWrites;

    public ComputePassDescriptorFFI()
    {
    }

}
