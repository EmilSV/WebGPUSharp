using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint EntryCount;
    public required BindGroupLayoutEntry* Entries;

    public BindGroupLayoutDescriptorFFI()
    {
    }

}
