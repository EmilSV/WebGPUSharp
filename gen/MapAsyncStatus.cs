using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum MapAsyncStatus
{
    Success = 1,
    InstanceDropped = 2,
    Error = 3,
    Aborted = 4,
}
