using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The type of a texture sample.
/// </summary>
public enum TextureSampleType
{
    BindingNotUsed = 0,
    /// <summary>
    /// No value is passed for this argument.
    /// </summary>
    Undefined = 1,
    /// <summary>
    /// Sampling returns floats.
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var my_storage_image: texture_storage_2d&lt;32float&gt;;
    /// </code></example>
    /// </summary>
    Float = 2,
    /// <summary>
    /// A single-precision floating-point value that is unfilterable.
    /// </summary>
    UnfilterableFloat = 3,
    /// <summary>
    /// Sampling does the depth reference comparison.
    /// 
    /// This is also compatible with a non-filtering sampler.
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var t: texture_depth_2d;
    /// </code></example>
    /// </summary>
    Depth = 4,
    /// <summary>
    /// Sampling returns signed integers.
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var t: texture_2d&lt;i32&gt;;
    /// </code></example>
    /// </summary>
    Sint = 5,
    /// <summary>
    /// Sampling returns unsigned integers.
    /// <example>
    /// Example WGSL syntax:
    /// <code language="WGSL">
    /// @group(0) @binding(0)
    /// var t: texture_2d&lt;u32&gt;;
    /// </code></example>
    /// </summary>
    Uint = 6,
}
