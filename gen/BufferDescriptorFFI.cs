using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BufferDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = new();
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
    ///  <see cref="WebGpuSharp.Buffer.GetMappedRange"/> to be called immediately. It is valid to set
    ///  <see cref="WebGpuSharp.BufferDescriptor.MappedAtCreation"/> to `true` even if  <see cref="WebGpuSharp.BufferDescriptor.Usage"/>
    /// does not contain  <see cref="BufferUsage.MAP_READ"/> or  <see cref="BufferUsage.MAP_WRITE"/>. This can be
    /// used to set the buffer's initial data.
    /// Guarantees that even if the buffer creation eventually fails, it will still appear as if the
    /// mapped range can be written/read to until it is unmapped.
    /// </summary>
    public WebGPUBool MappedAtCreation = false;

    public BufferDescriptorFFI() { }

}
