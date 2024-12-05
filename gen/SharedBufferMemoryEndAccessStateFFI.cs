using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedBufferMemoryEndAccessStateFFI
{
    public ChainedStructOut* NextInChain;
    public WebGPUBool Initialized = new();
    public nuint FenceCount;
    public SharedFenceHandle* Fences;
    public ulong* SignaledValues;

    public SharedBufferMemoryEndAccessStateFFI() { }

}
