using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a <see cref="CommandBufferHandle" /> to be created.
/// </summary>
public unsafe partial struct CommandBufferDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of this command buffer.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;

    public CommandBufferDescriptorFFI() { }

}
