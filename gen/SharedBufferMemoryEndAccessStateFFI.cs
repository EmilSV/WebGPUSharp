using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedBufferMemoryEndAccessStateFFI
{
    public ChainedStructOut* NextInChain;
    public WebGPUBool Initialized;
    public nuint FenceCount;
    public SharedFenceHandle* Fences;
    public ulong* SignaledValues;

    public SharedBufferMemoryEndAccessStateFFI()
    {
    }


    public SharedBufferMemoryEndAccessStateFFI(ChainedStructOut* nextInChain = default, WebGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
    {
        this.NextInChain = nextInChain;
        this.Initialized = initialized;
        this.FenceCount = fenceCount;
        this.Fences = fences;
        this.SignaledValues = signaledValues;
    }


    public SharedBufferMemoryEndAccessStateFFI(WebGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
    {
        this.Initialized = initialized;
        this.FenceCount = fenceCount;
        this.Fences = fences;
        this.SignaledValues = signaledValues;
    }

}
