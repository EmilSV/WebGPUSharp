using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="PassTimestampWritesFFI"/>
public struct PassTimestampWrites :
    IWebGpuFFIConvertible<PassTimestampWrites, PassTimestampWritesFFI>
{
    /// <inheritdoc cref="PassTimestampWritesFFI.QuerySet"/>
    public required QuerySet QuerySet;
    /// <inheritdoc cref="PassTimestampWritesFFI.BeginningOfPassWriteIndex"/>
    public uint BeginningOfPassWriteIndex;
    /// <inheritdoc cref="PassTimestampWritesFFI.EndOfPassWriteIndex"/>
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