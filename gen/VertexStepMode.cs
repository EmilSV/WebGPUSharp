using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum VertexStepMode
{
    Undefined = 0,
    VertexBufferNotUsed = 1,
    /// <summary>
    /// The address is advanced by  <see cref="WebGpuSharp.VertexBufferLayout.ArrayStride"/> for each vertex,
    /// and reset between instances.
    /// </summary>
    Vertex = 2,
    /// <summary>
    /// The address is advanced by  <see cref="WebGpuSharp.VertexBufferLayout.ArrayStride"/> for each instance.
    /// </summary>
    Instance = 3,
}
