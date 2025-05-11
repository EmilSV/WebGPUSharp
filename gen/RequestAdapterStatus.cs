using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the status of a request to get an adapter.
/// </summary>
public enum RequestAdapterStatus
{
    /// <summary>
    /// The request was completed successfully.
    /// </summary>
    Success = 1,
    /// <summary>
    /// The callback was cancelled.
    /// </summary>
    CallbackCancelled = 2,
    /// <summary>
    /// No adapter could be found that matches the request.
    /// </summary>
    Unavailable = 3,
    /// <summary>
    /// An error occurred while requesting the adapter.
    /// </summary>
    Error = 4,
}
