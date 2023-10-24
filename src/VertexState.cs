using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp;

public partial struct VertexState :
    IUnsafeMarshalAlloc<VertexState, VertexStateFFI>
{
    public ShaderModule Module;
    public string EntryPoint;
    public ConstantEntryList? Constants;
    public VertexBufferLayoutList? Buffers;

    static unsafe void IUnsafeMarshalAlloc<VertexState, VertexStateFFI>.UnsafeMarshalTo(
        in VertexState input, WebGpuAllocatorHandle allocator, ref VertexStateFFI dest)
    {
        ToFFI(input.Module, out dest.Module);
        ToFFI(input.EntryPoint, allocator, out dest.EntryPoint);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        ToFFI(input.Buffers, allocator, out dest.Buffers, out dest.BufferCount);
    }
}