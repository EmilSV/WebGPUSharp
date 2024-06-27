using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum WaitStatus
{
    Success = 1,
    TimedOut = 2,
    UnsupportedTimeout = 3,
    UnsupportedCount = 4,
    UnsupportedMixedSources = 5,
    Unknown = 6,
}
