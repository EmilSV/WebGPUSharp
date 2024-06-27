using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Origin3D
{
    public uint X;
    public uint Y;
    public uint Z;

    public Origin3D()
    {
    }


    public Origin3D(uint x = default, uint y = default, uint z = default)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

}
