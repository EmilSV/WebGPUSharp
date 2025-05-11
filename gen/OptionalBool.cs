using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// An enum representing an optional boolean value.
/// </summary>
public enum OptionalBool
{
    /// <summary>
    /// The value is false.
    /// </summary>
    False = 0,
    /// <summary>
    /// The value is true.
    /// </summary>
    True = 1,
    /// <summary>
    /// The value is undefined.
    /// </summary>
    Undefined = 2,
}
