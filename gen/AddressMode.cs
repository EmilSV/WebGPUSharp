using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum AddressMode
{
    Undefined = 0,
    ClampToEdge = 1,
    Repeat = 2,
    MirrorRepeat = 3,
}
