using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPipelineDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public PipelineLayoutHandle Layout;
    public required VertexStateFFI Vertex;
    public PrimitiveState Primitive;
    public DepthStencilState* DepthStencil;
    public MultisampleState Multisample;
    public FragmentStateFFI* Fragment;

    public RenderPipelineDescriptorFFI()
    {
    }

}
