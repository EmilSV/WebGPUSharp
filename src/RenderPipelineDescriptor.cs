using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI"/>
[StructLayout(LayoutKind.Auto)]
public ref struct RenderPipelineDescriptor
{
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.Label"/>
    public WGPURefText Label;
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.Layout"/>
    public required PipelineLayoutBase? Layout;
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.Vertex"/>
    public required ref readonly VertexState Vertex;
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.Primitive"/>
    public PrimitiveState Primitive = new();
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.DepthStencil"/>
    public WGPUNullableRef<DepthStencilState> DepthStencil;
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.Multisample"/>
    public MultisampleState Multisample = new();
    /// <inheritdoc cref="FFI.RenderPipelineDescriptorFFI.Fragment"/>
    public WGPUNullableRef<FragmentState> Fragment;

    public RenderPipelineDescriptor()
    {
    }
}