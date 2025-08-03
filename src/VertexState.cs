using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="VertexStateFFI" />
public struct VertexState : IWebGpuFFIConvertibleAlloc<VertexState, VertexStateFFI>
{
    /// <inheritdoc cref="VertexStateFFI.Module" />
    public required ShaderModule Module;
    /// <inheritdoc cref="VertexStateFFI.EntryPoint" />
    public string? EntryPoint;
    /// <inheritdoc cref="VertexStateFFI.Constants" />
    public WebGpuManagedSpan<ConstantEntry> Constants;
    /// <inheritdoc cref="VertexStateFFI.Buffers" />
    public WebGpuManagedSpan<VertexBufferLayout> Buffers;

    static unsafe void IWebGpuFFIConvertibleAlloc<VertexState, VertexStateFFI>.UnsafeConvertToFFI(
        in VertexState input, WebGpuAllocatorHandle allocator, out VertexStateFFI dest)
    {
        dest = default;
        dest.Module = GetBorrowHandle(input.Module);
        dest.EntryPoint = ToStringViewFFI(input.EntryPoint, allocator);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        ToFFI(input.Buffers, allocator, out dest.Buffers, out dest.BufferCount);
    }
}