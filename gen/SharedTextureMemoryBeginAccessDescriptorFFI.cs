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

    public SharedTextureMemoryBeginAccessDescriptorFFI() { }

}
