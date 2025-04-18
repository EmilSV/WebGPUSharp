using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A struct containing the SPIR-V code and its size
/// </summary>
public unsafe partial struct ShaderSourceSPIRVFFI
{
    /// <summary>
    /// The chain link for struct chaining
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The size of the SPIR-V code
    /// </summary>
    public uint CodeSize;
    /// <summary>
    /// The SPIR-V code
    /// </summary>
    public uint* Code;

    public ShaderSourceSPIRVFFI() { }

}
