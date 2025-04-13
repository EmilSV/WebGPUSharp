using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the state of primitive assembly and rasterization in a render pipeline.
/// </summary>
public unsafe partial struct PrimitiveState
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The type of primitive to be constructed from the vertex inputs.
    /// </summary>
    public PrimitiveTopology Topology = PrimitiveTopology.TriangleList;
    /// <summary>
    /// For pipelines with strip topologies
    /// ( <see cref="PrimitiveTopology.Line-strip"/> or  <see cref="PrimitiveTopology.Triangle-strip"/>),
    /// this determines the index buffer format and primitive restart value
    /// ( <see cref="IndexFormat.Uint16"/>/`0xFFFF` or  <see cref="IndexFormat.Uint32"/>/`0xFFFFFFFF`).
    /// It is not allowed on pipelines with non-strip topologies.
    /// Note: Some implementations require knowledge of the primitive restart value to compile
    /// pipeline state objects.
    /// To use a strip-topology pipeline with an indexed draw call
    /// (RenderCommandsMixin.DrawIndexed or RenderCommandsMixin.DrawIndexedIndirect),
    /// this must be set, and it must match the index buffer format used with the draw call
    /// (set in RenderCommandsMixin.SetIndexBuffer).
    /// See #primitive-assembly for additional details.
    /// </summary>
    public IndexFormat StripIndexFormat;
    /// <summary>
    /// Defines which polygons are considered front-facing.
    /// </summary>
    public FrontFace FrontFace = FrontFace.CCW;
    /// <summary>
    /// Defines which polygon orientation will be culled, if any.
    /// </summary>
    public CullMode CullMode = CullMode.None;
    /// <summary>
    /// If true, indicates that depth clipping is disabled.
    /// Requires the  <see cref="FeatureName.Depth-clip-control"/> feature to be enabled.
    /// </summary>
    public WebGPUBool UnclippedDepth = false;

    public PrimitiveState() { }

}
