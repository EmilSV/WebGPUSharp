using System.Runtime.InteropServices;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public ref struct RenderPipelineDescriptor
{
    public WGPURefText Label;
    public required PipelineLayout Layout;
    public required ref readonly VertexState Vertex;
    public required PrimitiveState Primitive;
    public WGPUNullableRef<DepthStencilState> DepthStencil;
    public required ref readonly MultisampleState Multisample;
    public WGPUNullableRef<FragmentState> Fragment;
}