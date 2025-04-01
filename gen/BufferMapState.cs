using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The state of a buffer mapping.
/// </summary>
public enum BufferMapState
{
    /// <summary>
    /// The buffer is not mapped for use by <see cref="Buffer.GetMappedRange" />.
    /// </summary>
    Unmapped = 1,
    /// <summary>
    /// A mapping of the buffer has been requested, but is pending.
    /// It may succeed, or fail validation in  <see cref="Buffer.MapAsync"/>.
    /// </summary>
    Pending = 2,
    /// <summary>
    /// The buffer is mapped and <see cref="Buffer.GetMappedRange" /> may be used.
    /// </summary>
    Mapped = 3,
}
