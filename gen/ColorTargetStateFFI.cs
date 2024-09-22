using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ColorTargetStateFFI
{
    public ChainedStruct* NextInChain;
    public required TextureFormat Format;
    public BlendState* Blend;
    public ColorWriteMask WriteMask = ColorWriteMask.All;

    public ColorTargetStateFFI()
    {
    }

}
