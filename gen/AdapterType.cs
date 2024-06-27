using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum AdapterType
{
    DiscreteGPU = 1,
    IntegratedGPU = 2,
    CPU = 3,
    Unknown = 4,
}
