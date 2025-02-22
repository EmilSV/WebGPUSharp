using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a <see cref="BindGroupLayoutHandle" />
/// </summary>
public unsafe partial struct BindGroupLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A label to apply to the bind group layout.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The number of entries in the <see cref="Entries" /> array.
    /// </summary>
    public nuint EntryCount;
    /// <summary>
    /// A list of entries describing the shader resource bindings for a bind group.
    /// </summary>
    public required BindGroupLayoutEntry* Entries;

    public BindGroupLayoutDescriptorFFI() { }

}
