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
    /// The work done event was fired, but the instance was dropped before the event could fire.
    /// </summary>
    InstanceDropped = 2,
    /// <summary>
    /// The work done event was fired, but an error occurred.
    /// </summary>
    Error = 3,
}
