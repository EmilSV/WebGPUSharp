using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The status of the last call to <see cref="Surface.GetCurrentTexture" />.
/// </summary>
public enum SurfaceGetCurrentTextureStatus
{
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was successful and the texture is optimal.
    /// </summary>
    SuccessOptimal = 1,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was successful and the texture is suboptimal.
    /// </summary>
    SuccessSuboptimal = 2,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> timed out.
    /// </summary>
    Timeout = 3,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was outdated.
    /// </summary>
    Outdated = 4,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> was lost.
    /// </summary>
    Lost = 5,
    /// <summary>
    /// The call to <see cref="Surface.GetCurrentTexture" /> failed due to an error.
    /// </summary>
    Error = 6,
}
