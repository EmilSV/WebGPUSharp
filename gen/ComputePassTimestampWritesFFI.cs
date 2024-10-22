using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePassTimestampWritesFFI
{
    /// <summary>
    /// The  <see cref="WebGpuSharp.QuerySet"/>, of type  <see cref="QueryType.Timestamp"/>, that the query results will be
    /// written to.
    /// </summary>
    public required QuerySetHandle QuerySet;
    /// <summary>
    /// If defined, indicates the query index in  <see cref="WebGpuSharp.RenderPassTimestampWrites.QuerySet"/> into
    /// which the timestamp at the beginning of the compute pass will be written.
    /// </summary>
    public uint BeginningOfPassWriteIndex;
    /// <summary>
    /// If defined, indicates the query index in  <see cref="WebGpuSharp.RenderPassTimestampWrites.QuerySet"/> into
    /// which the timestamp at the end of the compute pass will be written.
    /// </summary>
    public uint EndOfPassWriteIndex;

    public ComputePassTimestampWritesFFI() { }

}
