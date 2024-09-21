using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct BlendComponent
{
    public BlendOperation Operation = BlendOperation.Add;
    public BlendFactor SrcFactor = BlendFactor.One;
    public BlendFactor DstFactor = BlendFactor.Zero;

    public BlendComponent()
    {
    }

}
