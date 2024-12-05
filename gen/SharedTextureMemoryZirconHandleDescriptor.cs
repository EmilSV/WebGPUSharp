using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryZirconHandleDescriptor
{
    public ChainedStruct Chain = new();
    public uint MemoryFD;
    public ulong AllocationSize;

    public SharedTextureMemoryZirconHandleDescriptor() { }

}
