using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Extent3D
{
    public required uint Width;
    public uint Height = 1;
    public uint DepthOrArrayLayers = 1;

    public Extent3D()
    {
    }

}
