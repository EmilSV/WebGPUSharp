using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The face culling mode.
/// </summary>
public enum CullMode
{
    /// <summary>
    /// The face culling mode is not defined.
    /// </summary>
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
