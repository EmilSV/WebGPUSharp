using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPipelineDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public PipelineLayoutHandle Layout;
    /// <summary>
    /// Describes the vertex shader entry point of thepipelineand its input buffer layouts.
    /// </summary>
    public required VertexStateFFI Vertex;
    /// <summary>
    /// Describes the primitive-related properties of thepipeline.
    /// </summary>
    public PrimitiveState Primitive;
    /// <summary>
    /// Describes the optional depth-stencil properties, including the testing, operations, and bias.
    /// </summary>
    public DepthStencilState* DepthStencil;
    /// <summary>
    /// Describes the multi-sampling properties of thepipeline.
    /// </summary>
    public MultisampleState Multisample;
    /// <summary>
    /// Describes the fragment shader entry point of thepipelineand its output colors. If
    /// notprovided, the#no-color-outputmode is enabled.
    /// </summary>
    public FragmentStateFFI* Fragment;

    public RenderPipelineDescriptorFFI()
    {
    }

}
