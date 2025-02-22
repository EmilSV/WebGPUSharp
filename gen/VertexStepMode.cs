using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The step mode configures how an address for vertex buffer data is computed, based on the current vertex or instance index:
/// <list type="bullet"><item><description>
/// Vertex: The address is advanced by arrayStride for each vertex, and reset between instances.
/// </description></item><item><description>
/// Instance: the address is advanced by arrayStride for each instance.
/// </description></item></list>
/// </summary>
public enum VertexStepMode
{
    Undefined = 0,
    /// <summary>
    /// The address is advanced by  <see cref="WebGpuSharp.VertexBufferLayout.ArrayStride"/> for each vertex,
    /// and reset between instances.
    /// </summary>
    Vertex = 1,
    /// <summary>
    /// The address is advanced by  <see cref="WebGpuSharp.VertexBufferLayout.ArrayStride"/> for each instance.
    /// </summary>
    Instance = 2,
}
