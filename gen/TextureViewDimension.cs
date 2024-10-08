using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureViewDimension
{
    Undefined = 0,
    D1 = 1,
    D2 = 2,
    D2Array = 3,
    /// <summary>
    /// The texture is viewed as a cubemap.
    /// The view has 6 array layers, each corresponding to a face of the cube in the order
    /// `[+X, -X, +Y, -Y, +Z, -Z]` and the following orientations:
    /// <figure>
    /// <figcaption>
    /// Cubemap faces.
    /// The +U/+V axes indicate the individual faces' texture coordinates,
    /// and thus the image copy memory layout of each face.
    /// </figcaption>
    /// <object type="image/svg+xml" data="img/cubemap.svg" width=350 height=260></object>
    /// </figure>
    /// Note: When viewed from the inside, this results in a left-handed coordinate system
    /// where +X is right, +Y is up, and +Z is forward.
    /// Sampling is done seamlessly across the faces of the cubemap.
    /// Corresponding WGSL types:
    /// - `texture_cube`
    /// - `texture_depth_cube`
    /// </summary>
    Cube = 4,
    /// <summary>
    /// The texture is viewed as a packed array of n cubemaps,
    /// each with 6 array layers behaving like one  <see cref="Cube"/> view,
    /// for 6n array layers in total.
    /// Corresponding WGSL types:
    /// - `texture_cube_array`
    /// - `texture_depth_cube_array`
    /// </summary>
    CubeArray = 5,
    D3 = 6,
}
