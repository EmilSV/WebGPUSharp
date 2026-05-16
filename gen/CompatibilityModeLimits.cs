using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Limit specifically for compatibility mode. You can read more at <see href="https://webgpufundamentals.org/webgpu/lessons/webgpu-compatibility-mode.html">WebGPU Fundamentals Compatibility Mode</see>.
/// </summary>
public partial struct CompatibilityModeLimits
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// Maximum number of storage buffers that can be accessed from the vertex stage in compatibility mode.
    /// Defaults to 0.
    /// </summary>
    public uint MaxStorageBuffersInVertexStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage textures that can be accessed from the vertex stage in compatibility mode.
    /// Defaults to 0.
    /// </summary>
    public uint MaxStorageTexturesInVertexStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage buffers that can be accessed from the fragment stage in compatibility mode.
    /// Defaults to 4.
    /// </summary>
    public uint MaxStorageBuffersInFragmentStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage textures that can be accessed from the fragment stage in compatibility mode.
    /// Defaults to 4.
    /// </summary>
    public uint MaxStorageTexturesInFragmentStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;

    public CompatibilityModeLimits() { }

}
