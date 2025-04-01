using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A struct containing the SPIR-V code and its size.
/// </summary>
public unsafe partial struct ShaderSourceSPIRVFFI
{
    public ChainedStruct Chain;
    public uint CodeSize;
    /// <summary>
    /// The SPIR-V code.
    /// </summary>
    public uint* Code;

    public ShaderSourceSPIRVFFI() { }

}
