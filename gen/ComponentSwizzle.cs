using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Used by <see cref="TextureComponentSwizzle" /> to specify how the components of a texture are swizzled when accessed by a shader.
/// </summary>
public enum ComponentSwizzle
{
    /// <summary>
    /// Indicates no value is passed for this argument.
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Force its value to 0.
    /// </summary>
    Zero = 1,
    /// <summary>
    /// Force its value to 1.
    /// </summary>
    One = 2,
    /// <summary>
    /// Take its value from the red channel of the texture.
    /// </summary>
    R = 3,
    /// <summary>
    /// Take its value from the green channel of the texture.
    /// </summary>
    G = 4,
    /// <summary>
    /// Take its value from the blue channel of the texture.
    /// </summary>
    B = 5,
    /// <summary>
    /// Take its value from the alpha channel of the texture.
    /// </summary>
    A = 6,
}
