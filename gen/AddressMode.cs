using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// describes the behavior of the sampler if the sampled texels extend beyond the
/// bounds of the sampled texture.
/// </summary>
public enum AddressMode
{
    /// <summary>
    /// No address mode is specified. (uses default address mode)
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Texture coordinates are clamped between 0.0 and 1.0, inclusive.
    /// </summary>
    ClampToEdge = 1,
    /// <summary>
    /// Texture coordinates wrap to the other side of the texture.
    /// </summary>
    Repeat = 2,
    /// <summary>
    /// Texture coordinates wrap to the other side of the texture, but the texture is flipped
    /// when the integer part of the coordinate is odd.
    /// </summary>
    MirrorRepeat = 3,
}
