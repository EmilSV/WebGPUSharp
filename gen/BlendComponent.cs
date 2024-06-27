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


    public BlendComponent(BlendOperation operation = default, BlendFactor srcFactor = default, BlendFactor dstFactor = default)
    {
        this.Operation = operation;
        this.SrcFactor = srcFactor;
        this.DstFactor = dstFactor;
    }

}
