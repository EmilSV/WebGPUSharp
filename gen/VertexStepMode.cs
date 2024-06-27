using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum VertexStepMode
{
    Undefined = 0,
    VertexBufferNotUsed = 1,
    Vertex = 2,
    Instance = 3,
}
