using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum QueueWorkDoneStatus
{
    Success = 1,
    InstanceDropped = 2,
    Error = 3,
    Unknown = 4,
    DeviceLost = 5,
}
