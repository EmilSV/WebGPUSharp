using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The  <see cref="BindGroupLayout"/> the entries of this bind group will conform to.
    /// </summary>
    public required BindGroupLayoutHandle Layout;
    public nuint EntryCount;
    /// <summary>
    /// A list of entries describing the resources to expose to the shader for each binding
    /// described by the  <see cref="BindGroupDescriptor.Layout"/>.
    /// </summary>
    public required BindGroupEntryFFI* Entries;

    public BindGroupDescriptorFFI() { }

}
