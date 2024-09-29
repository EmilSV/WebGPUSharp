using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Extent3D
{
    /// <summary>
    /// The width of the extent.
    /// </summary>
    public required uint Width;
    /// <summary>
    /// The height of the extent.
    /// </summary>
    public uint Height = 1;
    /// <summary>
    /// The depth of the extent or the number of array layers it contains.
    /// If used with a  <see cref="FFI.Texture"/> with a  <see cref="TextureDimension"/> of  <see cref="TextureDimension."3d""/>
    /// defines the depth of the texture. If used with a  <see cref="FFI.Texture"/> with a  <see cref="TextureDimension"/>
    /// of  <see cref="TextureDimension."2d""/> defines the number of array layers in the texture.
    /// </summary>
    public uint DepthOrArrayLayers = 1;

    public Extent3D()
    {
    }

}
