using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The type of GPU adapter.
/// </summary>
public enum AdapterType
{
    /// <summary>
    /// Discrete GPU with separate CPU/GPU memory.
    /// </summary>
    DiscreteGPU = 1,
    /// <summary>
    /// Integrated GPU with shared CPU/GPU memory.
    /// </summary>
    IntegratedGPU = 2,
    /// <summary>
    /// Cpu / Software Rendering.
    /// </summary>
    CPU = 3,
    /// <summary>
    /// Unknown or other
    /// </summary>
    Unknown = 4,
}
