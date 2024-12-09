using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = StringViewFFI.NullValue;
    public nuint EntryCount;
    /// <summary>
    /// A list of entries describing the shader resource bindings for a bind group.
    /// </summary>
    public required BindGroupLayoutEntry* Entries;

    public BindGroupLayoutDescriptorFFI() { }

}
