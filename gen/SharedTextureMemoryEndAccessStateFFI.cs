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

    public SharedTextureMemoryEndAccessStateFFI()
    {
    }


    public SharedTextureMemoryEndAccessStateFFI(ChainedStructOut* nextInChain = default, WebGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
    {
        this.NextInChain = nextInChain;
        this.Initialized = initialized;
        this.FenceCount = fenceCount;
        this.Fences = fences;
        this.SignaledValues = signaledValues;
    }


    public SharedTextureMemoryEndAccessStateFFI(WebGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
    {
        this.Initialized = initialized;
        this.FenceCount = fenceCount;
        this.Fences = fences;
        this.SignaledValues = signaledValues;
    }

}
