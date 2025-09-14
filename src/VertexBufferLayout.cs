using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="VertexBufferLayoutFFI" />
public struct VertexBufferLayout :
    IWebGpuMarshallableAlloc<VertexBufferLayout, VertexBufferLayoutFFI>
{
    /// <inheritdoc cref="VertexBufferLayoutFFI.ArrayStride" />
    public required ulong ArrayStride;
    /// <inheritdoc cref="VertexBufferLayoutFFI.StepMode" />
    public VertexStepMode StepMode = VertexStepMode.Vertex;
    /// <inheritdoc cref="VertexBufferLayoutFFI.Attributes" />
    public required WebGpuManagedSpan<VertexAttribute> Attributes;

    public VertexBufferLayout()
    {

    }

    static unsafe void IWebGpuMarshallableAlloc<VertexBufferLayout, VertexBufferLayoutFFI>.MarshalToFFI(
        in VertexBufferLayout input,
        WebGpuAllocatorHandle allocator,
        out VertexBufferLayoutFFI dest)
    {
        dest = default;
        dest.ArrayStride = input.ArrayStride;
        dest.StepMode = input.StepMode;
        var attributesSpan = input.Attributes.InternalGetAsSpan();
        if (attributesSpan.IsEmpty)
        {
            dest.Attributes = default;
            dest.AttributeCount = 0;
        }
        else
        {
            // If the attributes span is not empty, we convert it to FFI format
            dest.AttributeCount = (nuint)attributesSpan.Length;
            dest.Attributes = allocator.Alloc<VertexAttribute>(dest.AttributeCount);
            var destAttributesSpan = new Span<VertexAttribute>(dest.Attributes, attributesSpan.Length);
            attributesSpan.CopyTo(destAttributesSpan);
        }
    }
}