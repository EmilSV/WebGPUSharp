namespace WebGpuSharp;

/// <inheritdoc cref="FFI.VertexBufferLayoutFFI" />
public struct VertexBufferLayout
{
    /// <inheritdoc cref="FFI.VertexBufferLayoutFFI.ArrayStride" />
    public required ulong ArrayStride;
    /// <inheritdoc cref="FFI.VertexBufferLayoutFFI.StepMode" />
    public VertexStepMode StepMode = VertexStepMode.Vertex;
    /// <inheritdoc cref="FFI.VertexBufferLayoutFFI.Attributes" />
    public required VertexAttributeList Attributes;

    public VertexBufferLayout()
    {

    }
}