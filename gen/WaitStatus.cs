using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The status of a wait operation.
/// </summary>
public enum WaitStatus
{
    /// <summary>
    /// The wait operation was successful.
    /// </summary>
    Success = 1,
    /// <summary>
    /// The wait operation timed out.
    /// </summary>
    TimedOut = 2,
    /// <summary>
    /// An error occurred during the wait operation.
    /// </summary>
    Error = 3,
}
