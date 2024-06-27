using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct VertexAttribute
{
    public VertexFormat Format;
    public ulong Offset;
    public uint ShaderLocation;

    public VertexAttribute()
    {
    }


    public VertexAttribute(VertexFormat format = default, ulong offset = default, uint shaderLocation = default)
    {
        this.Format = format;
        this.Offset = offset;
        this.ShaderLocation = shaderLocation;
    }

}
