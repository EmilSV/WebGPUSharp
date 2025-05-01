using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// View of a texture which can be used to copy to/from a buffer.
/// </summary>
public unsafe partial struct TexelCopyTextureInfoFFI
{
    /// <summary>
    /// The texture to be copied to/from.
    /// </summary>
    public TextureHandle Texture;
    /// <summary>
    /// The target mip level of the texture.
    /// </summary>
    public uint MipLevel;
    /// <summary>
    /// The base texel of the texture in the selected <see cref="MipLevel" />.
    /// Together with the copySize argument to copy functions, defines the sub-region of the texture to copy.
    /// </summary>
    public Origin3D Origin = new();
    /// <summary>
    /// The copy aspect.
    /// </summary>
    public TextureAspect Aspect;

    public TexelCopyTextureInfoFFI() { }

}
