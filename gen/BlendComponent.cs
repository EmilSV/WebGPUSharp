using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct BlendComponent
{
    public BlendOperation Operation;
    public BlendFactor SrcFactor;
    public BlendFactor DstFactor;

    public BlendComponent()
    {
    }


    public BlendComponent(BlendOperation operation = BlendOperation.Add, BlendFactor srcFactor = BlendFactor.One, BlendFactor dstFactor = BlendFactor.Zero)
    {
        this.Operation = operation;
        this.SrcFactor = srcFactor;
        this.DstFactor = dstFactor;
    }

}
