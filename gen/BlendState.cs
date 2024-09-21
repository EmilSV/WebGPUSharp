using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct BlendState
{
    public required BlendComponent Color;
    public required BlendComponent Alpha;

    public BlendState()
    {
    }

}
