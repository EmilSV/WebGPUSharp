using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
/// <summary>
/// Type of buffer mapping.
/// </summary>
public enum MapMode : ulong
{
    /// <summary>
    /// No mapping.
    /// </summary>
    None = 0,
    /// <summary>
    /// Map only for reading
    /// </summary>
    Read = 1,
    /// <summary>
    /// Map only for writing
    /// </summary>
    Write = 2,
}
