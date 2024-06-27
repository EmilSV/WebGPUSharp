using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryOpaqueFDDescriptorFFI
{
    public ChainedStruct Chain;
    public void* VkImageCreateInfo;
    public int MemoryFD;
    public uint MemoryTypeIndex;
    public ulong AllocationSize;
    public WebGPUBool DedicatedAllocation;

    public SharedTextureMemoryOpaqueFDDescriptorFFI()
    {
    }


    public SharedTextureMemoryOpaqueFDDescriptorFFI(ChainedStruct chain = default, void* vkImageCreateInfo = default, int memoryFD = default, uint memoryTypeIndex = default, ulong allocationSize = default, WebGPUBool dedicatedAllocation = default)
    {
        this.Chain = chain;
        this.VkImageCreateInfo = vkImageCreateInfo;
        this.MemoryFD = memoryFD;
        this.MemoryTypeIndex = memoryTypeIndex;
        this.AllocationSize = allocationSize;
        this.DedicatedAllocation = dedicatedAllocation;
    }

}
