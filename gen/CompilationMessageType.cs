using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The type of a compilation message.
/// </summary>
public enum CompilationMessageType
{
    /// <summary>
    /// An error message.
    /// </summary>
    Error = 1,
    /// <summary>
    /// A warning message.
    /// </summary>
    Warning = 2,
    /// <summary>
    /// An informational message.
    /// </summary>
    Info = 3,
}
