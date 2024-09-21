using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyTextureFFI
{
    public required TextureHandle Texture;
    public uint MipLevel = 0;
    public Origin3D Origin;
    public TextureAspect Aspect = TextureAspect.All;

    public ImageCopyTextureFFI()
    {
    }

}
