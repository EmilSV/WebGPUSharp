using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A string view is a reference to a utf8 string in memory. It is used to pass strings to WebGPU APIs.
/// </summary>
public unsafe partial struct StringViewFFI
{
    /// <summary>
    /// The data of the string view
    /// </summary>
    public byte* Data;
    /// <summary>
    /// The length of the string view
    /// </summary>
    public nuint Length = WebGPU_FFI.STRLEN;
    /// <summary>
    /// A null string view
    /// </summary>
    public static readonly StringViewFFI NullValue = new() { Data = null, Length = WebGPU_FFI.STRLEN };

    public StringViewFFI() { }

}
