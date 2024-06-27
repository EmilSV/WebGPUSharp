using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum DeviceLostReason
{
    Unknown = 1,
    Destroyed = 2,
    InstanceDropped = 3,
    FailedCreation = 4,
}
