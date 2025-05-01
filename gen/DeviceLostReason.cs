using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Reason for “lose the device”.
/// </summary>
public enum DeviceLostReason
{
    /// <summary>
    /// Triggered by driver
    /// </summary>
    Unknown = 1,
    /// <summary>
    /// The device was destroyed by <see cref="Device.Destroy()" />
    /// </summary>
    Destroyed = 2,
    CallbackCancelled = 3,
    /// <summary>
    /// The device was lost because it failed to be created.
    /// </summary>
    FailedCreation = 4,
}
