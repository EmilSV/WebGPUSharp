using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Extent2D
{
    public uint Width;
    public uint Height;

    public Extent2D()
    {
    }


    public Extent2D(uint width = default, uint height = default)
    {
        this.Width = width;
        this.Height = height;
    }

}
