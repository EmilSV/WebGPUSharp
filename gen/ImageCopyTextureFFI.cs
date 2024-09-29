using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyTextureFFI
{
    /// <summary>
    /// Texture to copy to/from.
    /// </summary>
    public required TextureHandle Texture;
    /// <summary>
    /// Mip-map level of the  <see cref="FFI.ImageCopyTexture.Texture"/> to copy to/from.
    /// </summary>
    public uint MipLevel = 0;
    /// <summary>
    /// Defines the origin of the copy - the minimum corner of the texture sub-region to copy to/from.
    /// Together with `copySize`, defines the full copy sub-region.
    /// </summary>
    public Origin3D Origin;
    /// <summary>
    /// Defines which aspects of the  <see cref="FFI.ImageCopyTexture.Texture"/> to copy to/from.
    /// </summary>
    public TextureAspect Aspect = TextureAspect.All;

    public ImageCopyTextureFFI()
    {
    }

}
