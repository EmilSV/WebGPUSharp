using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the shader stages that a binding will be visible from.
/// These can be combined so something that is visible from both vertex and fragment shaders can be defined as:
/// <see cref="Vertex" /> | <see cref="Fragment" />
/// </summary>
[Flags]
public enum ShaderStage : ulong
{
    /// <summary>
    /// Binding is not visible from any shader stage.
    /// </summary>
    None = 0,
    /// <summary>
    /// Binding is visible from the vertex shader of a render pipeline.
    /// </summary>
    Vertex = 1,
    /// <summary>
    /// Binding is visible from the fragment shader of a render pipeline.
    /// </summary>
    Fragment = 2,
    /// <summary>
    /// Binding is visible from the compute shader of a compute pipeline.
    /// </summary>
    Compute = 4,
}
