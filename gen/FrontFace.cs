using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum FrontFace
{
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
