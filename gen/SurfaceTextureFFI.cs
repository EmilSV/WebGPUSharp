using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceTextureFFI
{
    public TextureHandle Texture;
    public WebGPUBool Suboptimal = new();
    public SurfaceGetCurrentTextureStatus Status;

    public SurfaceTextureFFI() { }

}
