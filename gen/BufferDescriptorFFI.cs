using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BufferDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public required BufferUsage Usage;
    public required ulong Size;
    public WebGPUBool MappedAtCreation = false;

    public BufferDescriptorFFI()
    {
    }

}
