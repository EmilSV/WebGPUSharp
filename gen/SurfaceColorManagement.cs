using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Extension of <see cref="SurfaceConfiguration" /> for color spaces and HDR.
/// </summary>
public partial struct SurfaceColorManagement
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The color space to use for the surface. This is a hint to the implementation about the color space of the surface.
    /// </summary>
    public PredefinedColorSpace ColorSpace;
    /// <summary>
    /// The tone mapping mode to use for the surface. This is a hint to the implementation about how to map HDR colors to SDR colors.
    /// </summary>
    public ToneMappingMode ToneMappingMode;

    public SurfaceColorManagement() { }

}
