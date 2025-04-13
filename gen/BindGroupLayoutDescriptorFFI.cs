using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a <see cref="BindGroupLayoutHandle" />
/// </summary>
public unsafe partial struct BindGroupLayoutDescriptorFFI
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
