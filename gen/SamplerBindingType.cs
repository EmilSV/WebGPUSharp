using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum SamplerBindingType
{
    BindingNotUsed = 0,
    Undefined = 1,
    Filtering = 2,
    NonFiltering = 3,
    Comparison = 4,
}
