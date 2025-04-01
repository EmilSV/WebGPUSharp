using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Defines which polygons are considered front-facing by a <see cref="RenderPipeline" />
/// </summary>
public enum FrontFace
{
    /// <summary>
    /// Indicates no value is passed for this argument
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Polygons with vertices whose framebuffer coordinates are given in counter-clockwise order
    /// are considered front-facing.
    /// </summary>
    CCW = 1,
    /// <summary>
    /// Polygons with vertices whose framebuffer coordinates are given in clockwise order are
    /// considered front-facing.
    /// </summary>
    CW = 2,
}
