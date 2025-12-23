using WebGpuSharp.FFI;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="PassTimestampWritesFFI"/>
public struct PassTimestampWrites :
    IWebGpuMarshallable<PassTimestampWrites, PassTimestampWritesFFI>
{
    /// <inheritdoc cref="PassTimestampWritesFFI.QuerySet"/>
    public required QuerySet QuerySet;
    /// <summary>
    /// If defined, indicates the query index in <see cref="QuerySet" /> into which the timestamp at the beginning of the render pass will be written.
    /// </summary>
    public uint BeginningOfPassWriteIndex;
    /// <summary>
    /// If defined, indicates the query index in <see cref="QuerySet" /> into which the timestamp at the end of the render pass will be written.
    /// </summary>
    public uint EndOfPassWriteIndex;

    static void IWebGpuMarshallable<PassTimestampWrites, PassTimestampWritesFFI>.MarshalToFFI(
        in PassTimestampWrites input, out PassTimestampWritesFFI dest)
    {
        dest = new()
        {
            QuerySet = WebGPUMarshal.GetHandle(input.QuerySet),
            BeginningOfPassWriteIndex = input.BeginningOfPassWriteIndex,
            EndOfPassWriteIndex = input.EndOfPassWriteIndex
        };
    }
}