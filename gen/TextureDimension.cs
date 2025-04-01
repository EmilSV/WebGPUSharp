using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Dimensionality of a texture.
/// </summary>
public enum TextureDimension
{
    Undefined = 0,
    /// <summary>
    /// 1D texture
    /// </summary>
    D1 = 1,
    /// <summary>
    /// 2D texture
    /// </summary>
    D2 = 2,
    /// <summary>
    /// 3D texture
    /// </summary>
    D3 = 3,
}
