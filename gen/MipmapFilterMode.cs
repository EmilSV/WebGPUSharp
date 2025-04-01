using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Filter mode to use when sampling from a texture's mipmap level.
/// </summary>
public enum MipmapFilterMode
{
    /// <summary>
    /// Indicates no value is passed for this argument
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Return the value of the texel nearest to the texture coordinates.
    /// </summary>
    Nearest = 1,
    /// <summary>
    /// Select two texels in each dimension and return a linear interpolation between their values.
    /// </summary>
    Linear = 2,
}
