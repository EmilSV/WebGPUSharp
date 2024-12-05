using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyExternalTextureFFI
{
    public ChainedStruct* NextInChain;
    public ExternalTextureHandle ExternalTexture;
    public Origin3D Origin = new();
    public Extent2D NaturalSize = new();

    public ImageCopyExternalTextureFFI() { }

}
