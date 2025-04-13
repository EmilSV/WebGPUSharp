using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the attachments of a compute pass.
/// For use with <see cref="FFI.CommandEncoder.BeginComputePass" />.
/// </summary>
public unsafe partial struct ComputePassDescriptorFFI
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
    /// Debug label of the compute pass.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// Defines which timestamp values will be written for this pass, and where to write them to.
    /// </summary>
    public PassTimestampWritesFFI* TimestampWrites;

    public ComputePassDescriptorFFI() { }

}
