using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryOpaqueFDDescriptorFFI
{
    public ChainedStruct Chain = new();
    public void* VkImageCreateInfo;
    public int MemoryFD;
    public uint MemoryTypeIndex;
    public ulong AllocationSize;
    public WebGPUBool DedicatedAllocation = new();

    public SharedTextureMemoryOpaqueFDDescriptorFFI() { }

}
