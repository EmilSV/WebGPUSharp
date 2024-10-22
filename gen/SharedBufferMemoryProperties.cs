using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SharedBufferMemoryProperties
{
    public ChainedStructOut* NextInChain;
    public BufferUsage Usage;
    public ulong Size;

    public SharedBufferMemoryProperties() { }

}
