using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a PipelineLayout.
/// </summary>
public unsafe partial struct PipelineLayoutDescriptorFFI
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
    /// Debug label of the pipeline layout. This will show up in graphics debuggers for easy identification.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// the number of bind groups in the BindGroupLayouts sequence.
    /// </summary>
    public nuint BindGroupLayoutCount;
    /// <summary>
    /// Bind groups that this pipeline uses. The first entry will provide all the bindings for “set = 0”, second entry will provide all the bindings for “set = 1” etc.
    /// </summary>
    public required BindGroupLayoutHandle* BindGroupLayouts;
    public uint ImmediateSize;

    public PipelineLayoutDescriptorFFI() { }

}
