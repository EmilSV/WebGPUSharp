using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Type of query contained in a <see cref="QuerySet" />.
/// </summary>
public enum QueryType
{
    /// <summary>
    /// Query returns a single 64-bit number, serving as an occlusion boolean.
    /// </summary>
    Occlusion = 1,
    /// <summary>
    /// Query returns a 64-bit number indicating the GPU-timestamp where all previous commands have finished executing.
    /// </summary>
    Timestamp = 2,
}
