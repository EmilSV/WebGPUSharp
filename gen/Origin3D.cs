using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Origin of a copy to/from a texture.
/// </summary>
public partial struct Origin3D
{
    /// <summary>
    /// X position of the origin
    /// </summary>
    public uint X = 0;
    /// <summary>
    /// Y position of the origin
    /// </summary>
    public uint Y = 0;
    /// <summary>
    /// Z position of the origin
    /// </summary>
    public uint Z = 0;

    public Origin3D() { }

}
