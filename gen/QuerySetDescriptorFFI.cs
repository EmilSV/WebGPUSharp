using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Specifies the options to use in creating a QuerySet.
/// </summary>
public unsafe partial struct QuerySetDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of the QuerySet
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The type of queries managed by  <see cref="QuerySet"/>.
    /// </summary>
    public required QueryType Type;
    /// <summary>
    /// The number of queries managed by  <see cref="QuerySet"/>.
    /// </summary>
    public required uint Count;

    public QuerySetDescriptorFFI() { }

}
