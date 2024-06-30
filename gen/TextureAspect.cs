using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureAspect
{
    Undefined = 0,
    All = 1,
    StencilOnly = 2,
    DepthOnly = 3,
    Plane0Only = 327680,
    Plane1Only = 327681,
    Plane2Only = 327682,
}
