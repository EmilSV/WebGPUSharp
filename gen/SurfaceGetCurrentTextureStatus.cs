using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum SurfaceGetCurrentTextureStatus
{
    Success = 1,
    Timeout = 2,
    Outdated = 3,
    Lost = 4,
    OutOfMemory = 5,
    DeviceLost = 6,
    Error = 7,
}
