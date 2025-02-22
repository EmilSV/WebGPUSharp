using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// BufferBindingType is used to define the type of a buffer binding.
/// </summary>
public enum BufferBindingType
{
    BindingNotUsed = 0,
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
