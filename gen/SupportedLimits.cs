using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// A struct containing the limits supported by the WebGPU API.
/// </summary>
public unsafe partial struct SupportedLimits
{
    public ChainedStruct* NextInChain;
    public Limits Limits = new();

    public SupportedLimits() { }

}
