using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// When accessed by a shader, the red/green/blue/alpha channels are replaced
/// by the value corresponding to the component specified in r, g, b, and a.
/// </summary>
public partial struct TextureComponentSwizzle
{
    /// <summary>
    /// The value that replaces the red channel in the shader.
    /// </summary>
    public ComponentSwizzle R;
    /// <summary>
    /// The value that replaces the green channel in the shader.
    /// </summary>
    public ComponentSwizzle G;
    /// <summary>
    /// The value that replaces the blue channel in the shader.
    /// </summary>
    public ComponentSwizzle B;
    /// <summary>
    /// The value that replaces the alpha channel in the shader.
    /// </summary>
    public ComponentSwizzle A;

    public TextureComponentSwizzle() { }

}
