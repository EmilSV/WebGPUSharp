using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a group of bindings and the resources to be bound.
/// </summary>
public unsafe partial struct BindGroupDescriptorFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of the bind group
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The <see cref="BindGroupLayout" /> the entries of
    /// this bind group will conform to.
    /// </summary>
    public required BindGroupLayoutHandle Layout;
    /// <summary>
    /// the number of entries at <see cref="Entries" />
    /// </summary>
    public nuint EntryCount;
    /// <summary>
    /// A list of entries describing the resources to expose to the shader for each binding
    /// described by the  <see cref="BindGroupDescriptor.Layout"/>.
    /// </summary>
    public required BindGroupEntryFFI* Entries;

    public BindGroupDescriptorFFI() { }

}
