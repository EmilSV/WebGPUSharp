using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The status of the last call to <see cref="Surface.GetCurrentTexture" />.
/// </summary>
public enum SurfaceGetCurrentTextureStatus
{
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was successful.
    /// </summary>
    Success = 1,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> timed out.
    /// </summary>
    Timeout = 2,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was outdated.
    /// </summary>
    Outdated = 3,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was lost.
    /// </summary>
    Lost = 4,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> failed due to out of memory.
    /// </summary>
    OutOfMemory = 5,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> failed due to the device being lost.
    /// </summary>
    DeviceLost = 6,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> failed due to an error.
    /// </summary>
    Error = 7,
}
