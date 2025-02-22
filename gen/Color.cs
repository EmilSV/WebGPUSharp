using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// A color with red, green, blue and alpha channels.
/// </summary>
public partial struct Color
{
    /// <summary>
    /// The red channel value.
    /// </summary>
    public required double R;
    /// <summary>
    /// The green channel value.
    /// </summary>
    public required double G;
    /// <summary>
    /// The blue channel value.
    /// </summary>
    public required double B;
    /// <summary>
    /// The alpha channel value.
    /// </summary>
    public required double A;

    public Color() { }

}
