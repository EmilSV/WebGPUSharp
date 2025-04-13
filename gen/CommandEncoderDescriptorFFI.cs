using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a CommandEncoder. For use with <see cref="DeviceHandle.CreateCommandEncoder(WebGpuSharp.FFI.CommandEncoderDescriptorFFI*)" />
/// </summary>
public unsafe partial struct CommandEncoderDescriptorFFI
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
    /// The debug label of the command encoder.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;

    public CommandEncoderDescriptorFFI() { }

}
