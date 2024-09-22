using System.Diagnostics.CodeAnalysis;

namespace WebGpuSharp;

public partial struct Extent3D
{
    [SetsRequiredMembers]
    public Extent3D(uint width, uint height = 1, uint depthOrArrayLayers = 1)
    {
        Width = width;
        Height = height;
        DepthOrArrayLayers = depthOrArrayLayers;
    }
}
