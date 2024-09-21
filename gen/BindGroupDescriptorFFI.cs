using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public required BindGroupLayoutHandle Layout;
    public nuint EntryCount;
    public required BindGroupEntryFFI* Entries;

    public BindGroupDescriptorFFI()
    {
    }

}
