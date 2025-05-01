using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes how the vertex buffer is interpreted.
/// </summary>
public unsafe partial struct VertexBufferLayoutFFI
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
    /// Whether each element of this array represents per-vertex data or per-instance data
    /// </summary>
    public VertexStepMode StepMode = VertexStepMode.Vertex;
    /// <summary>
    /// The stride, in bytes, between elements of this array.
    /// </summary>
    public required ulong ArrayStride;
    /// <summary>
    /// The amount of attributes in the <see cref="VertexBufferLayoutFFI" /> sequence.
    /// </summary>
    public nuint AttributeCount;
    /// <summary>
    /// An array defining the layout of the vertex attributes within each element.
    /// </summary>
    public required VertexAttribute* Attributes;

    public VertexBufferLayoutFFI() { }

}
