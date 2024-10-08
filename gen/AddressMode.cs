using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum AddressMode
{
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
