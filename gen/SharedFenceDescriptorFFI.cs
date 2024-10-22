using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SharedFenceDescriptorFFI() { }

}