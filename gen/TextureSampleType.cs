using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureSampleType
{
    BindingNotUsed = 0,
    Undefined = 1,
    Float = 2,
    UnfilterableFloat = 3,
    Depth = 4,
    Sint = 5,
    Uint = 6,
}
