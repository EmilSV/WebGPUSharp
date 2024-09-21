using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct VertexBufferLayoutFFI
{
    public required ulong ArrayStride;
    public VertexStepMode StepMode = VertexStepMode.Vertex;
    public nuint AttributeCount;
    public required VertexAttribute* Attributes;

    public VertexBufferLayoutFFI()
    {
    }

}
