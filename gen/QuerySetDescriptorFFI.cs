using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QuerySetDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    /// <summary>
    /// The type of queries managed by  <see cref="WebGpuSharp.QuerySet"/>.
    /// </summary>
    public required QueryType Type;
    /// <summary>
    /// The number of queries managed by  <see cref="WebGpuSharp.QuerySet"/>.
    /// </summary>
    public required uint Count;

    public QuerySetDescriptorFFI() { }

}
