using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the required limits of a device.
/// </summary>
public unsafe partial struct RequiredLimits
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The required limits of the device.
    /// </summary>
    public Limits Limits = new();

    public RequiredLimits() { }

}
