using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureAspect
{
    Undefined = 0,
    All = 1,
    StencilOnly = 2,
    DepthOnly = 3,
}
