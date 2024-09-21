using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct VertexAttribute
{
    public required VertexFormat Format;
    public required ulong Offset;
    public required uint ShaderLocation;

    public VertexAttribute()
    {
    }

}
