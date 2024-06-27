using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum BlendFactor
{
    Undefined = 0,
    Zero = 1,
    One = 2,
    Src = 3,
    OneMinusSrc = 4,
    SrcAlpha = 5,
    OneMinusSrcAlpha = 6,
    Dst = 7,
    OneMinusDst = 8,
    DstAlpha = 9,
    OneMinusDstAlpha = 10,
    SrcAlphaSaturated = 11,
    Constant = 12,
    OneMinusConstant = 13,
    Src1 = 14,
    OneMinusSrc1 = 15,
    Src1Alpha = 16,
    OneMinusSrc1Alpha = 17,
}
