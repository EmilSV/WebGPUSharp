using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CreatePipelineAsyncStatus
{
    Success = 1,
    InstanceDropped = 2,
    ValidationError = 3,
    InternalError = 4,
    DeviceLost = 5,
    DeviceDestroyed = 6,
    Unknown = 7,
}
