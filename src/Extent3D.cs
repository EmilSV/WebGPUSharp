using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Extent3D
{
    public Extent3D(uint width, uint height = 1, uint depthOrArrayLayers = 1)
    {
        Width = width;
        Height = height;
        DepthOrArrayLayers = depthOrArrayLayers;
    }
}
