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


    public Extent3D(uint width = default, uint height = default, uint depthOrArrayLayers = default)
    {
        this.Width = width;
        this.Height = height;
        this.DepthOrArrayLayers = depthOrArrayLayers;
    }

}
