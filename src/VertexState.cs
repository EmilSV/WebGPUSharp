using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct VertexState :
    IWebGpuFFIConvertibleAlloc<VertexState, VertexStateFFI>
{
    public required ShaderModule Module;
    public string EntryPoint;
    public ConstantEntryList? Constants;
    public VertexBufferLayoutList? Buffers;

    static unsafe void IWebGpuFFIConvertibleAlloc<VertexState, VertexStateFFI>.UnsafeConvertToFFI(
        in VertexState input, WebGpuAllocatorHandle allocator, out VertexStateFFI dest)
    {
        dest = default;
        ToFFI(input.Module, out dest.Module);
        ToFFI(input.EntryPoint, allocator, out dest.EntryPoint);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        ToFFI(input.Buffers, allocator, out dest.Buffers, out dest.BufferCount);
    }
}