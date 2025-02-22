using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The status of a wait operation.
/// </summary>
public enum WaitStatus
{
    Success = 1,
    TimedOut = 2,
    Error = 3,
}
