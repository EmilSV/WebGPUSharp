using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CullMode
{
    Undefined = 0,
    /// <summary>
    /// No polygons are discarded.
    /// </summary>
    None = 1,
    /// <summary>
    /// Front-facing polygons are discarded.
    /// </summary>
    Front = 2,
    /// <summary>
    /// Back-facing polygons are discarded.
    /// </summary>
    Back = 3,
}
