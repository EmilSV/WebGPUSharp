using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A struct containing the WGSL code.
/// </summary>
public unsafe partial struct ShaderSourceWGSLFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The WGSL code.
    /// </summary>
    public StringViewFFI Code = StringViewFFI.NullValue;

    public ShaderSourceWGSLFFI() { }

}
