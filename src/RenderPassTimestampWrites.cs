using WebGpuSharp.FFI;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="PassTimestampWritesFFI"/>
public struct PassTimestampWrites :
    IWebGpuMarshallable<PassTimestampWrites, PassTimestampWritesFFI>
{
    /// <inheritdoc cref="PassTimestampWritesFFI.QuerySet"/>
    public required QuerySet QuerySet;
    /// <inheritdoc cref="PassTimestampWritesFFI.BeginningOfPassWriteIndex"/>
    public uint BeginningOfPassWriteIndex;
    /// <inheritdoc cref="PassTimestampWritesFFI.EndOfPassWriteIndex"/>
    public uint EndOfPassWriteIndex;

    static void IWebGpuMarshallable<PassTimestampWrites, PassTimestampWritesFFI>.MarshalToFFI(
        in PassTimestampWrites input, out PassTimestampWritesFFI dest)
    {
        dest = new()
        {
            QuerySet = WebGPUMarshal.GetBorrowHandle(input.QuerySet),
            BeginningOfPassWriteIndex = input.BeginningOfPassWriteIndex,
            EndOfPassWriteIndex = input.EndOfPassWriteIndex
        };
    }
}