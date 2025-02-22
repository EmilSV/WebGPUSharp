using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A key-value pair used for fragment, vertex, and compute shader constants.
/// </summary>
public unsafe partial struct ConstantEntryFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The name of the constant.
    /// </summary>
    public StringViewFFI Key = StringViewFFI.NullValue;
    /// <summary>
    /// The value of the constant.
    /// </summary>
    public double Value;

    public ConstantEntryFFI() { }

}
