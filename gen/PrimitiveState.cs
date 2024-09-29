using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct PrimitiveState
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The type of primitive to be constructed from the vertex inputs.
    /// </summary>
    public PrimitiveTopology Topology = PrimitiveTopology.TriangleList;
    /// <summary>
    /// For pipelines with strip topologies
    /// ( <see cref="PrimitiveTopology."line-strip""/> or  <see cref="PrimitiveTopology."triangle-strip""/>),
    /// this determines the index buffer format and primitive restart value
    /// ( <see cref="IndexFormat."uint16""/>/`0xFFFF` or  <see cref="IndexFormat."uint32""/>/`0xFFFFFFFF`).
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
    /// Requires the  <see cref="FeatureName."depth-clip-control""/> feature to be enabled.
    /// </summary>
    public WebGPUBool UnclippedDepth = false;

    public PrimitiveState()
    {
    }

}
