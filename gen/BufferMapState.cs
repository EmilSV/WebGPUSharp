using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum BufferMapState
{
    Unmapped = 1,
    Pending = 2,
    Mapped = 3,
}
