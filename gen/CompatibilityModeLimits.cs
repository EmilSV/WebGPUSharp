using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct CompatibilityModeLimits
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    public uint MaxStorageBuffersInVertexStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    public uint MaxStorageTexturesInVertexStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    public uint MaxStorageBuffersInFragmentStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    public uint MaxStorageTexturesInFragmentStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;

    public CompatibilityModeLimits() { }

}
