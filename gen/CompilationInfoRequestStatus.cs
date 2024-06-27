using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CompilationInfoRequestStatus
{
    Success = 1,
    InstanceDropped = 2,
    Error = 3,
    DeviceLost = 4,
    Unknown = 5,
}
