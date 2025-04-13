using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupEntryFFI
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
    /// A unique identifier for a resource binding within the  <see cref="BindGroup"/>, corresponding to a
    ///  <see cref="BindGroupLayoutEntry.Binding">GPUBindGroupLayoutEntry.binding</see> and a @binding
    /// attribute in the  <see cref="ShaderModule"/>.
    /// </summary>
    public required uint Binding;
    public BufferHandle Buffer;
    public ulong Offset;
    public ulong Size;
    public SamplerHandle Sampler;
    public TextureViewHandle TextureView;

    public BindGroupEntryFFI() { }

}
