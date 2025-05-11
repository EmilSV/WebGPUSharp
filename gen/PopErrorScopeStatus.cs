using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The status of the PopErrorScope function.
/// </summary>
public enum PopErrorScopeStatus
{
    /// <summary>
    /// The error scope stack was successfully popped and a result was reported.
    /// </summary>
    Success = 1,
    /// <summary>
    /// This indicates that the callback was cancelled.
    /// </summary>
    CallbackCancelled = 2,
    /// <summary>
    /// The error scope stack could not be popped, because it was empty.
    /// </summary>
    Error = 3,
}
