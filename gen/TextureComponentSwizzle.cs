using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct TextureComponentSwizzle
{
    public ComponentSwizzle R;
    public ComponentSwizzle G;
    public ComponentSwizzle B;
    public ComponentSwizzle A;

    public TextureComponentSwizzle() { }

}
