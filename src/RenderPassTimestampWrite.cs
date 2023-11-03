using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp;

public struct RenderPassTimestampWrite :
    IWebGpuFFIConvertible<RenderPassTimestampWrite, RenderPassTimestampWriteFFI>
{
    public required QuerySet QuerySet;
    public uint QueryIndex;
    public RenderPassTimestampLocation Location;

    static void IWebGpuFFIConvertible<RenderPassTimestampWrite, RenderPassTimestampWriteFFI>.UnsafeConvertToFFI(
        in RenderPassTimestampWrite input, out RenderPassTimestampWriteFFI dest)
    {
        dest = new RenderPassTimestampWriteFFI(
            querySet: ToFFI<QuerySet, QuerySetHandle>(input.QuerySet),
            queryIndex: input.QueryIndex,
            location: input.Location
        );
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassTimestampWrite, RenderPassTimestampWriteFFI>.UnsafeConvertToFFI(
        in RenderPassTimestampWrite input, WebGpuAllocatorHandle allocator, out RenderPassTimestampWriteFFI dest)
    {
        ToFFI(input, out dest);
    }
}