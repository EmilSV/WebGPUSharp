using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// FeatureLevel is used to indicate the feature level of a WebGPU device.
/// </summary>
public enum FeatureLevel
{
    /// <summary>
    /// Feature level is undefined.
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Compatibility feature level.
    /// </summary>
    Compatibility = 1,
    /// <summary>
    /// Core feature level.
    /// </summary>
    Core = 2,
}
