using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the status of a request to get a device.
/// </summary>
public enum RequestDeviceStatus
{
    /// <summary>
    /// The request was completed successfully.
    /// </summary>
    Success = 1,
    /// <summary>
    /// The instance was dropped before the request could be completed.
    /// </summary>
    InstanceDropped = 2,
    /// <summary>
    /// An error occurred while requesting the device.
    /// </summary>
    Error = 3,
}
