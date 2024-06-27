using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct BlendState
{
    public BlendComponent Color;
    public BlendComponent Alpha;

    public BlendState()
    {
    }


    public BlendState(BlendComponent color = default, BlendComponent alpha = default)
    {
        this.Color = color;
        this.Alpha = alpha;
    }

}
