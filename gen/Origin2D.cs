using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Origin2D
{
    public uint X;
    public uint Y;

    public Origin2D()
    {
    }


    public Origin2D(uint x = default, uint y = default)
    {
        this.X = x;
        this.Y = y;
    }

}
