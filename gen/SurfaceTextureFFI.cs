using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface texture.
/// </summary>
public unsafe partial struct SurfaceTextureFFI
{
    /// <summary>
    /// The texture.
    /// </summary>
    public TextureHandle Texture;
    /// <summary>
    /// Whether the surface texture is suboptimal.
    /// </summary>
    public WebGPUBool Suboptimal = new();
    /// <summary>
    /// The status of the surface texture.
    /// </summary>
    public SurfaceGetCurrentTextureStatus Status;

    public SurfaceTextureFFI() { }

}
