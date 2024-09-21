using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ColorTargetStateFFI
{
    public ChainedStruct* NextInChain;
    public TextureFormat Format;
    public BlendState* Blend;
    public ColorWriteMask WriteMask;

    public ColorTargetStateFFI()
    {
    }


    public ColorTargetStateFFI(ChainedStruct* nextInChain = default, TextureFormat format = default, BlendState* blend = default, ColorWriteMask writeMask = 15)
    {
        this.NextInChain = nextInChain;
        this.Format = format;
        this.Blend = blend;
        this.WriteMask = writeMask;
    }


    public ColorTargetStateFFI(TextureFormat format = default, BlendState* blend = default, ColorWriteMask writeMask = 15)
    {
        this.Format = format;
        this.Blend = blend;
        this.WriteMask = writeMask;
    }

}
