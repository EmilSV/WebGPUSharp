using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the attachments of a compute pass.
/// For use with <see cref="FFI.CommandEncoder.BeginComputePass" />.
/// </summary>
public unsafe partial struct ComputePassDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of the compute pass.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// Defines which timestamp values will be written for this pass, and where to write them to.
    /// </summary>
    public PassTimestampWritesFFI* TimestampWrites;

    public ComputePassDescriptorFFI() { }

}
