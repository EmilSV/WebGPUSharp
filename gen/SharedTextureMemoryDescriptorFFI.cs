using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SharedTextureMemoryDescriptorFFI() { }

}
