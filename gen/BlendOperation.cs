using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// defines the algorithm used to combine source and destination blend factors
/// </summary>
public enum BlendOperation
{
    /// <summary>
    /// No BlendOperation is provided
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Src + Dst
    /// </summary>
    Add = 1,
    /// <summary>
    /// Src - Dst
    /// </summary>
    Subtract = 2,
    /// <summary>
    /// Dst - Src
    /// </summary>
    ReverseSubtract = 3,
    /// <summary>
    /// min(Src, Dst)
    /// </summary>
    Min = 4,
    /// <summary>
    /// max(Src, Dst)
    /// </summary>
    Max = 5,
}
