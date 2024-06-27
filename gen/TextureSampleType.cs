using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureSampleType
{
    Undefined = 0,
    Float = 1,
    UnfilterableFloat = 2,
    Depth = 3,
    Sint = 4,
    Uint = 5,
}
