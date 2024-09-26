using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct VertexAttribute
{
    /// <summary>
    /// The <see cref="VertexFormat"/>of the attribute.
    /// </summary>
    public required VertexFormat Format;
    /// <summary>
    /// The offset, in bytes, from the beginning of the element to the data for the attribute.
    /// </summary>
    public required ulong Offset;
    /// <summary>
    /// The numeric location associated with this attribute, which will correspond with a <a href="https://gpuweb.github.io/gpuweb/wgsl/#input-output-locations">"@location" attribute</a>declared in the <see cref="FFI.RenderPipelineDescriptor.Vertex"/>.ProgrammableStage.Module.
    /// </summary>
    public required uint ShaderLocation;

    public VertexAttribute()
    {
    }

}
