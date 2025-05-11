using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// BufferBindingType is used to define the type of a buffer binding.
/// </summary>
public enum BufferBindingType
{
    /// <summary>
    /// Indicates that this <see cref="BufferBindingLayout">BufferBindingLayout</see> member of
    /// its parent <see cref="BindGroupLayoutEntry">BindGroupLayoutEntry</see> is not used.
    /// </summary>
    BindingNotUsed = 0,
    /// <summary>
    /// No buffer binding type is provided.
    /// </summary>
    Undefined = 1,
    /// <summary>
    /// A buffer for uniform values
    /// </summary>
    Uniform = 2,
    /// <summary>
    /// A storage buffer.
    /// </summary>
    Storage = 3,
    /// <summary>
    /// A storage buffer. The buffer can only be read in the shader
    /// </summary>
    ReadOnlyStorage = 4,
}
