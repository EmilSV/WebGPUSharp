using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum RequestAdapterStatus
{
    Success = 1,
    InstanceDropped = 2,
    Unavailable = 3,
    Error = 4,
}
