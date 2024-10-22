using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct VertexBufferLayoutFFI
{
    /// <summary>
    /// The stride, in bytes, between elements of this array.
    /// </summary>
    public required ulong ArrayStride;
    /// <summary>
    /// Whether each element of this array represents per-vertex data or per-instance data
    /// </summary>
    public VertexStepMode StepMode = VertexStepMode.Vertex;
    public nuint AttributeCount;
    /// <summary>
    /// An array defining the layout of the vertex attributes within each element.
    /// </summary>
    public required VertexAttribute* Attributes;

    public VertexBufferLayoutFFI() { }

}
