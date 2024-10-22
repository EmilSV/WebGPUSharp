using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CommandBufferDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public CommandBufferDescriptorFFI() { }

}
