using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public BindGroupLayoutHandle Layout;
    public nuint EntryCount;
    public BindGroupEntryFFI* Entries;

    public BindGroupDescriptorFFI()
    {
    }


    public BindGroupDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, BindGroupLayoutHandle layout = default, nuint entryCount = default, BindGroupEntryFFI* entries = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Layout = layout;
        this.EntryCount = entryCount;
        this.Entries = entries;
    }


    public BindGroupDescriptorFFI(byte* label = default, BindGroupLayoutHandle layout = default, nuint entryCount = default, BindGroupEntryFFI* entries = default)
    {
        this.Label = label;
        this.Layout = layout;
        this.EntryCount = entryCount;
        this.Entries = entries;
    }

}
