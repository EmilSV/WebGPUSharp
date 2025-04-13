using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A key-value pair used for fragment, vertex, and compute shader constants.
/// </summary>
public unsafe partial struct ConstantEntryFFI
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
    /// The name of the constant.
    /// </summary>
    public StringViewFFI Key = StringViewFFI.NullValue;
    /// <summary>
    /// The value of the constant.
    /// </summary>
    public double Value;

    public ConstantEntryFFI() { }

}
