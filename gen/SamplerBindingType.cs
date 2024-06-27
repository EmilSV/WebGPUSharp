using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum SamplerBindingType
{
    Undefined = 0,
    Filtering = 1,
    NonFiltering = 2,
    Comparison = 3,
}
