using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Specifies the options to use in creating a QuerySet.
/// </summary>
public unsafe partial struct QuerySetDescriptorFFI
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
    /// Debug label of the QuerySet
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The type of queries managed by  <see cref="QuerySet"/>.
    /// </summary>
    public required QueryType Type;
    /// <summary>
    /// The number of queries managed by  <see cref="QuerySet"/>.
    /// </summary>
    public required uint Count;

    public QuerySetDescriptorFFI() { }

}
