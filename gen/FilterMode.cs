using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum FilterMode
{
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
