using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum LoadOp
{
    Undefined = 0,
    Clear = 1,
    Load = 2,
    ExpandResolveTexture = 3,
}
