using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a CommandEncoder. For use with <see cref="DeviceHandle.CreateCommandEncoder(WebGpuSharp.FFI.CommandEncoderDescriptorFFI*)" />
/// </summary>
public unsafe partial struct CommandEncoderDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The debug label of the command encoder.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;

    public CommandEncoderDescriptorFFI() { }

}
