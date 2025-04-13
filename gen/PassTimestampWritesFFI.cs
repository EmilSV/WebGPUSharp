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
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
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
