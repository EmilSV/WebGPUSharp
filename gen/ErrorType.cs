using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// An error type from the error stack
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// No error
    /// </summary>
    NoError = 1,
    /// <summary>
    /// Validation error, signifying a bug in code or data
    /// </summary>
    Validation = 2,
    /// <summary>
    /// Out of memory error
    /// </summary>
    OutOfMemory = 3,
    /// <summary>
    /// Internal error. Used for signalling any failures not explicitly expected by WebGPU.
    /// 
    /// These could be due to internal implementation or system limits being reached.
    /// </summary>
    Internal = 4,
    /// <summary>
    /// Unknown error
    /// </summary>
    Unknown = 5,
}
