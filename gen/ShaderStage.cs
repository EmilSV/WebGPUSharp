using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
public enum ShaderStage : ulong
{
    None = 0,
    Vertex = 1,
    Fragment = 2,
    Compute = 4,
}
