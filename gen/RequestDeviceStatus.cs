using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum RequestDeviceStatus
{
    Success = 1,
    InstanceDropped = 2,
    Error = 3,
}
