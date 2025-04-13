using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Buffer. For use with Device.CreateBuffer.
/// </summary>
public unsafe partial struct BufferDescriptorFFI
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
    /// Debug label of the Buffer
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The allowed usages for the buffer.
    /// </summary>
    public required BufferUsage Usage;
    /// <summary>
    /// The size of the buffer in bytes.
    /// </summary>
    public required ulong Size;
    /// <summary>
    /// If `true` creates the buffer in an already mapped state, allowing
    ///  <see cref="Buffer.GetMappedRange"/> to be called immediately. It is valid to set
    ///  <see cref="BufferDescriptor.MappedAtCreation"/> to `true` even if  <see cref="BufferDescriptor.Usage"/>
    /// does not contain  <see cref="BufferUsage.MAP_READ"/> or  <see cref="BufferUsage.MAP_WRITE"/>. This can be
    /// used to set the buffer's initial data.
    /// Guarantees that even if the buffer creation eventually fails, it will still appear as if the
    /// mapped range can be written/read to until it is unmapped.
    /// </summary>
    public WebGPUBool MappedAtCreation = false;

    public BufferDescriptorFFI() { }

}
