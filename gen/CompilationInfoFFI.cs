using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Compilation information for a shader module.
/// </summary>
public unsafe partial struct CompilationInfoFFI
{
    public ChainedStruct* NextInChain;
    public nuint MessageCount;
    /// <summary>
    /// The messages from the shader compilation process.
    /// </summary>
    public CompilationMessageFFI* Messages;

    public CompilationInfoFFI() { }

}
