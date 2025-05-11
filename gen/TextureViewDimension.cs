using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Dimensions of a particular texture view.
/// </summary>
public enum TextureViewDimension
{
    /// <summary>
    /// The texture view dimension is undefined.
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// The texture is viewed as a 1-dimensional image. Corresponding WGSL types: <list type="bullet"><item><description>texture_1d</description></item><item><description>texture_storage_1d</description></item></list>
    /// </summary>
    D1 = 1,
    /// <summary>
    /// The texture is viewed as a single 2-dimensional image. Corresponding WGSL
    /// types: <list type="bullet"><item><description>texture_2d</description></item><item><description>texture_storage_2d</description></item><item><description>texture_multisampled_2d</description></item><item><description>texture_depth_2d</description></item><item><description>texture_depth_multisampled_2d</description></item></list>
    /// </summary>
    D2 = 2,
    /// <summary>
    /// The texture view is viewed as an array of 2-dimensional images. Corresponding
    /// WGSL types: <list type="bullet"><item><description>texture_2d_array</description></item><item><description>texture_storage_2d_array</description></item><item><description>texture_depth_2d_array</description></item></list>
    /// </summary>
    D2Array = 3,
    /// <summary>
    /// The texture is viewed as a cubemap. The view has 6 array layers, each
    /// corresponding to a face of the cube in the order [+X, -X, +Y, -Y, +Z, -Z]. Sampling
    /// is done seamlessly across the faces of the cubemap. Corresponding WGSL types: <list type="bullet"><item><description>texture_cube</description></item><item><description>texture_depth_cube</description></item></list>
    /// </summary>
    Cube = 4,
    /// <summary>
    /// The texture is viewed as a packed array of n cubemaps, each with 6 array
    /// layers behaving like one <see cref="Cube" /> view, for 6n array layers in total.
    /// Corresponding WGSL types: <list type="bullet"><item><description>texture_cube_array</description></item><item><description>texture_depth_cube_array</description></item></list>
    /// </summary>
    CubeArray = 5,
    /// <summary>
    /// The texture is viewed as a 3-dimensional image. Corresponding WGSL types: <list type="bullet"><item><description>texture_3d</description></item><item><description>texture_storage_3d</description></item></list>
    /// </summary>
    D3 = 6,
}
