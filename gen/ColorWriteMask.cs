using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Bitmask controlling which channels are are written to
/// when drawing to this color target.
/// </summary>
[Flags]
public enum ColorWriteMask : ulong
{
    /// <summary>
    /// No channels are written to.
    /// </summary>
    None = 0,
    /// <summary>
    /// The red channel is written to.
    /// </summary>
    Red = 1,
    /// <summary>
    /// The green channel is written to.
    /// </summary>
    Green = 2,
    /// <summary>
    /// The blue channel is written to.
    /// </summary>
    Blue = 4,
    /// <summary>
    /// The alpha channel is written to.
    /// </summary>
    Alpha = 8,
    /// <summary>
    /// All channels are written to.
    /// </summary>
    All = 15,
}
