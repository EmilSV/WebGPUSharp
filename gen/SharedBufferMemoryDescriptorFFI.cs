using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedBufferMemoryDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SharedBufferMemoryDescriptorFFI() { }

}
