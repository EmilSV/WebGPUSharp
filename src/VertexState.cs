using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="VertexStateFFI" />
public struct VertexState : IWebGpuMarshallableAlloc<VertexState, VertexStateFFI>
{
    /// <inheritdoc cref="VertexStateFFI.Module" />
    public required ShaderModule Module;
    /// <inheritdoc cref="VertexStateFFI.EntryPoint" />
    public string? EntryPoint;
    /// <inheritdoc cref="VertexStateFFI.Constants" />
    public WebGpuManagedSpan<ConstantEntry> Constants;
    /// <inheritdoc cref="VertexStateFFI.Buffers" />
    public WebGpuManagedSpan<VertexBufferLayout> Buffers;

    static unsafe void IWebGpuMarshallableAlloc<VertexState, VertexStateFFI>.MarshalToFFI(
        in VertexState input, WebGpuAllocatorHandle allocator, out VertexStateFFI dest)
    {
        dest = default;
        dest.Module = GetBorrowHandle(input.Module);
        dest.EntryPoint = ToStringViewFFI(input.EntryPoint, allocator);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        ToFFI(input.Buffers, allocator, out dest.Buffers, out dest.BufferCount);
    }
}