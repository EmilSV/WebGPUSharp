using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct RenderPassDescriptorExpandResolveRect
{
    public ChainedStruct Chain;
    public uint X;
    public uint Y;
    public uint Width;
    public uint Height;

    public RenderPassDescriptorExpandResolveRect()
    {
    }


    public RenderPassDescriptorExpandResolveRect(ChainedStruct chain = default, uint x = default, uint y = default, uint width = default, uint height = default)
    {
        this.Chain = chain;
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

}
