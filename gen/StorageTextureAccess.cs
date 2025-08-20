using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Specific type of a sample in a texture binding.
/// 
/// For use in <see cref="WebGpuSharp.BindingType.StorageTexture" />.
/// </summary>
public enum StorageTextureAccess
{
    /// <summary>
    /// Indicates that this <see cref="StorageTextureBindingLayout" /> member of
    /// its parent <see cref="BindGroupLayoutEntry" /> is not used.
    /// </summary>
    BindingNotUsed = 0,
    /// <summary>
    /// No value is passed for this argument
    /// </summary>
    Undefined = 1,
    /// <summary>
    /// The texture can only be written in the shader and it:
    /// 
    /// may or may not be annotated with write (WGSL).
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var my_storage_image: texture_storage_2d&lt;r32float, write&gt;;
    /// </code></example>
    /// </summary>
    WriteOnly = 2,
    /// <summary>
    /// The texture can only be read in the shader and it must be annotated with read (WGSL) or readonly (GLSL).
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var my_storage_image: texture_storage_2d&lt;r32float, read&gt;;
    /// </code></example>
    /// </summary>
    ReadOnly = 3,
    /// <summary>
    /// The texture can be both read and written in the shader and must be annotated with read_write in WGSL.
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var my_storage_image: texture_storage_2d&lt;r32float, read_write&gt;;
    /// </code></example>
    /// </summary>
    ReadWrite = 4,
}
