using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
public enum ColorWriteMask : ulong
{
    None = 0,
    Red = 1,
    Green = 2,
    Blue = 4,
    Alpha = 8,
    All = 15,
}
