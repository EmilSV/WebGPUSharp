using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureViewDimension
{
    Undefined = 0,
    D1 = 1,
    D2 = 2,
    D2Array = 3,
    Cube = 4,
    CubeArray = 5,
    D3 = 6,
}
