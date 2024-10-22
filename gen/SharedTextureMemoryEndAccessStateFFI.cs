using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryEndAccessStateFFI
{
    public ChainedStructOut* NextInChain;
    public WebGPUBool Initialized;
    public nuint FenceCount;
    public SharedFenceHandle* Fences;
    public ulong* SignaledValues;

    public SharedTextureMemoryEndAccessStateFFI() { }

}