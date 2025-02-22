using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct PassTimestampWrites :
    IWebGpuFFIConvertible<PassTimestampWrites, PassTimestampWritesFFI>
{
    public required QuerySetBase QuerySet;
    public uint BeginningOfPassWriteIndex;
    public uint EndOfPassWriteIndex;

    static void IWebGpuFFIConvertible<PassTimestampWrites, PassTimestampWritesFFI>.UnsafeConvertToFFI(
        in PassTimestampWrites input, out PassTimestampWritesFFI dest)
    {
        dest = new()
        {
            QuerySet = WebGPUMarshal.GetBorrowHandle(input.QuerySet),
            BeginningOfPassWriteIndex = input.BeginningOfPassWriteIndex,
            EndOfPassWriteIndex = input.EndOfPassWriteIndex
        };
    }

    static void IWebGpuFFIConvertibleAlloc<PassTimestampWrites, PassTimestampWritesFFI>.UnsafeConvertToFFI(
        in PassTimestampWrites input, WebGpuAllocatorHandle allocator, out PassTimestampWritesFFI dest)
    {
        WebGPUMarshal.ToFFI(in input, allocator, out dest);
    }
}