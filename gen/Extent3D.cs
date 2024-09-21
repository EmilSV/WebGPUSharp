using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Extent3D
{
    public uint Width;
    public uint Height;
    public uint DepthOrArrayLayers;

    public Extent3D()
    {
    }

}
