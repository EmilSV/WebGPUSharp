using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryBeginAccessDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public WebGPUBool ConcurrentRead;
    public WebGPUBool Initialized;
    public nuint FenceCount;
    public SharedFenceHandle* Fences;
    public ulong* SignaledValues;

    public SharedTextureMemoryBeginAccessDescriptorFFI()
    {
    }


    public SharedTextureMemoryBeginAccessDescriptorFFI(ChainedStruct* nextInChain = default, WebGPUBool concurrentRead = default, WebGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
    {
        this.NextInChain = nextInChain;
        this.ConcurrentRead = concurrentRead;
        this.Initialized = initialized;
        this.FenceCount = fenceCount;
        this.Fences = fences;
        this.SignaledValues = signaledValues;
    }


    public SharedTextureMemoryBeginAccessDescriptorFFI(WebGPUBool concurrentRead = default, WebGPUBool initialized = default, nuint fenceCount = default, SharedFenceHandle* fences = default, ulong* signaledValues = default)
    {
        this.ConcurrentRead = concurrentRead;
        this.Initialized = initialized;
        this.FenceCount = fenceCount;
        this.Fences = fences;
        this.SignaledValues = signaledValues;
    }

}
