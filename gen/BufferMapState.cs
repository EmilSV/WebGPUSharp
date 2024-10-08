using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum BufferMapState
{
    /// <summary>
    /// The buffer is not mapped for use by `this`. <see cref="WebGpuSharp.Buffer.GetMappedRange"/>.
    /// </summary>
    Unmapped = 1,
    /// <summary>
    /// A mapping of the buffer has been requested, but is pending.
    /// It may succeed, or fail validation in  <see cref="WebGpuSharp.Buffer.MapAsync"/>.
    /// </summary>
    Pending = 2,
    /// <summary>
    /// The buffer is mapped and `this`. <see cref="WebGpuSharp.Buffer.GetMappedRange"/> may be used.
    /// </summary>
    Mapped = 3,
}
