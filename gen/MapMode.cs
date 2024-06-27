using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
public enum MapMode
{
    None = 0,
    Read = 1,
    Write = 2,
}
