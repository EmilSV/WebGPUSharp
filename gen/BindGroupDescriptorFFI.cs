using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    /// <summary>
    /// The  <see cref="WebGpuSharp.BindGroupLayout"/> the entries of this bind group will conform to.
    /// </summary>
    public required BindGroupLayoutHandle Layout;
    public nuint EntryCount;
    /// <summary>
    /// A list of entries describing the resources to expose to the shader for each binding
    /// described by the  <see cref="WebGpuSharp.BindGroupDescriptor.Layout"/>.
    /// </summary>
    public required BindGroupEntryFFI* Entries;

    public BindGroupDescriptorFFI()
    {
    }

}
