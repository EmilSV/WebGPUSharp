using System.Runtime.InteropServices;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public ref struct RenderPipelineDescriptor
{
    public WGPURefText Label;
    public required PipelineLayoutBase Layout;
    public required ref readonly VertexState Vertex;
    public PrimitiveState Primitive = new();
    public WGPUNullableRef<DepthStencilState> DepthStencil;
    public MultisampleState Multisample = new();
    public WGPUNullableRef<FragmentState> Fragment;

    public RenderPipelineDescriptor()
    {
    }
}