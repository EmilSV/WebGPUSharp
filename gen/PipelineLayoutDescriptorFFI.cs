using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a PipelineLayout.
/// </summary>
public unsafe partial struct PipelineLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of the pipeline layout. This will show up in graphics debuggers for easy identification.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// the number of bind groups in the BindGroupLayouts sequence.
    /// </summary>
    public nuint BindGroupLayoutCount;
    /// <summary>
    /// Bind groups that this pipeline uses. The first entry will provide all the bindings for “set = 0”, second entry will provide all the bindings for “set = 1” etc.
    /// </summary>
    public required BindGroupLayoutHandle* BindGroupLayouts;
    public uint ImmediateDataRangeByteSize;

    public PipelineLayoutDescriptorFFI() { }

}
