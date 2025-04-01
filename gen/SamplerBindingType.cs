using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Specific type of a sampler binding.
/// </summary>
public enum SamplerBindingType
{
    BindingNotUsed = 0,
    /// <summary>
    /// No sampler binding type specified.
    /// </summary>
    Undefined = 1,
    /// <summary>
    /// The sampling result is produced based on more than a single color sample from a texture, e.g. when bilinear interpolation is enabled.
    /// </summary>
    Filtering = 2,
    /// <summary>
    /// The sampling result is produced based on a single color sample from a texture.
    /// </summary>
    NonFiltering = 3,
    /// <summary>
    /// Use as a comparison sampler instead of a normal sampler.
    /// For more info take a look at the analogous functionality in <see href="https://www.khronos.org/opengl/wiki/Sampler_Object#Comparison_mode.">OpenGL</see>.
    /// </summary>
    Comparison = 4,
}
