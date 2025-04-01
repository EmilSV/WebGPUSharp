using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Vertex inputs (attributes) to shaders. Vertex attributes are assumed to be tightly packed.
/// </summary>
public partial struct VertexAttribute
{
    /// <summary>
    /// The  <see cref="VertexFormat"/> of the attribute.
    /// </summary>
    public required VertexFormat Format;
    /// <summary>
    /// The offset, in bytes, from the beginning of the element to the data for the attribute.
    /// </summary>
    public required ulong Offset;
    /// <summary>
    /// The numeric location associated with this attribute, which will correspond with a
    ///  <seealso href="https://gpuweb.github.io/gpuweb/wgsl/#input-output-locations">"@location" attribute</seealso>
    /// declared in the  <see cref="RenderPipelineDescriptor.Vertex"/>.ProgrammableStage.Module.
    /// </summary>
    public required uint ShaderLocation;

    public VertexAttribute() { }

}
