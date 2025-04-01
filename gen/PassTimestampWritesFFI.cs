using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the timestamp writes of a render pass.
/// 
/// For use with RenderPassDescriptor. At least one of BeginningOfPassWriteIndex and EndOfPassWriteIndex must have non undefined value.
/// </summary>
public unsafe partial struct PassTimestampWritesFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The <see cref="WebGpuSharp.QuerySet" />, of type <see cref="QueryType.Timestamp" />, that the query results will be written to.
    /// </summary>
    public QuerySetHandle QuerySet;
    /// <summary>
    /// If defined, indicates the query index in <see cref="WebGpuSharp.PassTimestampWritesFFI.QuerySet" /> into which the timestamp at the beginning of the render pass will be written.
    /// </summary>
    public uint BeginningOfPassWriteIndex = WebGPU_FFI.QUERY_SET_INDEX_UNDEFINED;
    /// <summary>
    /// If defined, indicates the query index in <see cref="WebGpuSharp.PassTimestampWritesFFI.QuerySet" /> into which the timestamp at the end of the render pass will be written.
    /// </summary>
    public uint EndOfPassWriteIndex = WebGPU_FFI.QUERY_SET_INDEX_UNDEFINED;

    public PassTimestampWritesFFI() { }

}
