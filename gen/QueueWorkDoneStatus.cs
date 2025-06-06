using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the status of a QueueWorkDone event.
/// </summary>
public enum QueueWorkDoneStatus
{
    /// <summary>
    /// The work done event was fired successfully.
    /// </summary>
    Success = 1,
    /// <summary>
    /// The callback was cancelled.
    /// </summary>
    CallbackCancelled = 2,
    /// <summary>
    /// The work done event was fired, but an error occurred.
    /// </summary>
    Error = 3,
}
