using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct BlendComponent
{
    /// <summary>
    /// Defines the <see cref="BlendOperation"/>used to calculate the values written to the target
    /// attachment components.
    /// </summary>
    public BlendOperation Operation = BlendOperation.Add;
    /// <summary>
    /// Defines the <see cref="BlendFactor"/>operation to be performed on values from the fragment shader.
    /// </summary>
    public BlendFactor SrcFactor = BlendFactor.One;
    /// <summary>
    /// Defines the <see cref="BlendFactor"/>operation to be performed on values from the target attachment.
    /// </summary>
    public BlendFactor DstFactor = BlendFactor.Zero;

    public BlendComponent()
    {
    }

}
