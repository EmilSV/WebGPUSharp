using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPipelineDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public PipelineLayoutHandle Layout;
    /// <summary>
    /// Describes the vertex shader entry point of the pipeline and its input buffer layouts.
    /// </summary>
    public required VertexStateFFI Vertex;
    /// <summary>
    /// Describes the primitive-related properties of the pipeline.
    /// </summary>
    public PrimitiveState Primitive;
    /// <summary>
    /// Describes the optional depth-stencil properties, including the testing, operations, and bias.
    /// </summary>
    public DepthStencilState* DepthStencil;
    /// <summary>
    /// Describes the multi-sampling properties of the pipeline.
    /// </summary>
    public MultisampleState Multisample;
    /// <summary>
    /// Describes the fragment shader entry point of the pipeline and its output colors. If
    /// not provided, the #no-color-output mode is enabled.
    /// </summary>
    public FragmentStateFFI* Fragment;

    public RenderPipelineDescriptorFFI() { }

}
