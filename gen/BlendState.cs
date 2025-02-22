using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describe the blend state of a render pipeline, within <see cref="FFI.ColorTargetStateFFI" />
/// </summary>
public partial struct BlendState
{
    /// <summary>
    /// Defines the blending behavior of the corresponding render target for color channels.
    /// </summary>
    public required BlendComponent Color;
    /// <summary>
    /// Defines the blending behavior of the corresponding render target for the alpha channel.
    /// </summary>
    public required BlendComponent Alpha;

    public BlendState() { }

}
