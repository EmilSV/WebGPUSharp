using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct VertexBufferLayoutFFI
{
    public ulong ArrayStride;
    public VertexStepMode StepMode;
    public nuint AttributeCount;
    public VertexAttribute* Attributes;

    public VertexBufferLayoutFFI()
    {
    }


    public VertexBufferLayoutFFI(ulong arrayStride = default, VertexStepMode stepMode = VertexStepMode.Vertex, nuint attributeCount = default, VertexAttribute* attributes = default)
    {
        this.ArrayStride = arrayStride;
        this.StepMode = stepMode;
        this.AttributeCount = attributeCount;
        this.Attributes = attributes;
    }

}
