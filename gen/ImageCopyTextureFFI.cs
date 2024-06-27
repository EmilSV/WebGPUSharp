using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyTextureFFI
{
    public TextureHandle Texture;
    public uint MipLevel;
    public Origin3D Origin;
    public TextureAspect Aspect;

    public ImageCopyTextureFFI()
    {
    }


    public ImageCopyTextureFFI(TextureHandle texture = default, uint mipLevel = default, Origin3D origin = default, TextureAspect aspect = default)
    {
        this.Texture = texture;
        this.MipLevel = mipLevel;
        this.Origin = origin;
        this.Aspect = aspect;
    }

}
