using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Status returned from a call to <see cref="Buffer.MapAsync" />.
/// </summary>
public enum MapAsyncStatus
{
    /// <summary>
    /// The operation was successful.
    /// </summary>
    Success = 1,
    /// <summary>
    /// The callback was cancelled.
    /// </summary>
    CallbackCancelled = 2,
    /// <summary>
    /// There was an error while mapping the buffer.
    /// </summary>
    Error = 3,
    /// <summary>
    /// The operation was aborted.
    /// </summary>
    Aborted = 4,
}
