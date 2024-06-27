using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryZirconHandleDescriptor
{
    public ChainedStruct Chain;
    public uint MemoryFD;
    public ulong AllocationSize;

    public SharedTextureMemoryZirconHandleDescriptor()
    {
    }


    public SharedTextureMemoryZirconHandleDescriptor(ChainedStruct chain = default, uint memoryFD = default, ulong allocationSize = default)
    {
        this.Chain = chain;
        this.MemoryFD = memoryFD;
        this.AllocationSize = allocationSize;
    }

}
