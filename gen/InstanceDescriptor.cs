using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The descriptor for the creation of an <see cref="Instance" />
/// </summary>
public unsafe partial struct InstanceDescriptor
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
    /// Instance capabilities to enable.
    /// </summary>
    public InstanceCapabilities Capabilities = new();
    [Obsolete("", false)]
    public InstanceCapabilities Features = new();

    public InstanceDescriptor() { }

}
