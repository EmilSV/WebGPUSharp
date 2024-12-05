using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct BlendState
{
    /// <summary>
    /// Defines the blending behavior of the corresponding render target for color channels.
    /// </summary>
    public required BlendComponent Color = new();
    /// <summary>
    /// Defines the blending behavior of the corresponding render target for the alpha channel.
    /// </summary>
    public required BlendComponent Alpha = new();

    public BlendState() { }

}
