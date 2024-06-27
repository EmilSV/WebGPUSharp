using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BufferDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public BufferUsage Usage;
    public ulong Size;
    public WebGPUBool MappedAtCreation;

    public BufferDescriptorFFI()
    {
    }


    public BufferDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, BufferUsage usage = default, ulong size = default, WebGPUBool mappedAtCreation = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Usage = usage;
        this.Size = size;
        this.MappedAtCreation = mappedAtCreation;
    }


    public BufferDescriptorFFI(byte* label = default, BufferUsage usage = default, ulong size = default, WebGPUBool mappedAtCreation = default)
    {
        this.Label = label;
        this.Usage = usage;
        this.Size = size;
        this.MappedAtCreation = mappedAtCreation;
    }

}
