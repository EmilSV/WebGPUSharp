using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SharedBufferMemoryProperties
{
    public ChainedStructOut* NextInChain;
    public BufferUsage Usage;
    public ulong Size;

    public SharedBufferMemoryProperties()
    {
    }


    public SharedBufferMemoryProperties(ChainedStructOut* nextInChain = default, BufferUsage usage = default, ulong size = default)
    {
        this.NextInChain = nextInChain;
        this.Usage = usage;
        this.Size = size;
    }


    public SharedBufferMemoryProperties(BufferUsage usage = default, ulong size = default)
    {
        this.Usage = usage;
        this.Size = size;
    }

}
