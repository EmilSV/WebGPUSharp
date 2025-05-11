using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Color spaces supported on the web.
/// </summary>
public enum PredefinedColorSpace
{
    /// <summary>
    /// The sRGB color space.
    /// </summary>
    SRGB = 1,
    /// <summary>
    /// The Display P3 color space.
    /// </summary>
    DisplayP3 = 2,
}
