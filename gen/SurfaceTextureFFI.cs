using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceTextureFFI
{
    public TextureHandle Texture;
    public WebGPUBool Suboptimal;
    public SurfaceGetCurrentTextureStatus Status;

    public SurfaceTextureFFI()
    {
    }


    public SurfaceTextureFFI(TextureHandle texture = default, WebGPUBool suboptimal = default, SurfaceGetCurrentTextureStatus status = default)
    {
        this.Texture = texture;
        this.Suboptimal = suboptimal;
        this.Status = status;
    }

}
