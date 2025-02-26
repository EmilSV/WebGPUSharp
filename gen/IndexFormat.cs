using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The index format determines both the data type of index values in a buffer and,
/// when used with strip primitive topologies (<see href="https://gpuweb.github.io/gpuweb/#dom-gpuprimitivetopology-line-strip">"line-strip"</see> or <see href="https://gpuweb.github.io/gpuweb/#dom-gpuprimitivetopology-triangle-strip">"triangle-strip"</see>) also
/// specifies the primitive restart value. The primitive restart value indicates which index
/// value indicates that a new primitive should be started rather than continuing to
/// construct the triangle strip with the prior indexed vertices.
/// </summary>
public enum IndexFormat
{
    /// <summary>
    /// Indicates no value is passed for this argument
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Indices are 16 bit unsigned integers.
    /// </summary>
    Uint16 = 1,
    /// <summary>
    /// Indices are 32 bit unsigned integers.
    /// </summary>
    Uint32 = 2,
}
