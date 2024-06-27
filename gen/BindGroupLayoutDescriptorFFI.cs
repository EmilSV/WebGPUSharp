using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint EntryCount;
    public BindGroupLayoutEntry* Entries;

    public BindGroupLayoutDescriptorFFI()
    {
    }


    public BindGroupLayoutDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint entryCount = default, BindGroupLayoutEntry* entries = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.EntryCount = entryCount;
        this.Entries = entries;
    }


    public BindGroupLayoutDescriptorFFI(byte* label = default, nuint entryCount = default, BindGroupLayoutEntry* entries = default)
    {
        this.Label = label;
        this.EntryCount = entryCount;
        this.Entries = entries;
    }

}
