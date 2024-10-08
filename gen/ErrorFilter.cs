using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum ErrorFilter
{
    /// <summary>
    /// Indicates that the error scope will catch a ValidationError.
    /// </summary>
    Validation = 1,
    /// <summary>
    /// Indicates that the error scope will catch a OutOfMemoryError.
    /// </summary>
    OutOfMemory = 2,
    /// <summary>
    /// Indicates that the error scope will catch a InternalError.
    /// </summary>
    Internal = 3,
}
