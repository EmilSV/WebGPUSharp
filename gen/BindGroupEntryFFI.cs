using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A single binding entry in a <see cref="WebGpuSharp.Bindgroup" />.
/// A BindgroupEntry can either bind a one of either a <see cref="BufferHandle" /> with offset and size,
/// or a <see cref="SamplerHandle" /> or <see cref="TextureViewHandle" />.
/// </summary>
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
    /// A unique identifier for a resource binding within the <see cref="WebGpuSharp.Bindgroup" />,
    /// corresponding to a <see cref="WebGpuSharp.BindgroupLayoutEntry.Binding" /> and
    /// a @binding attribute in the ShaderModule.
    /// </summary>
    public required uint Binding;
    /// <summary>
    /// The Buffer object you want to bind.
    /// </summary>
    public BufferHandle Buffer;
    /// <summary>
    /// The offset, in bytes, from the beginning of the buffer to the beginning of the range exposed to the shader by the buffer binding.
    /// </summary>
    public ulong Offset;
    /// <summary>
    /// The size, in bytes, of the buffer binding
    /// </summary>
    public ulong Size;
    /// <summary>
    /// The Sampler object you want to bind.
    /// </summary>
    public SamplerHandle Sampler;
    /// <summary>
    /// The TextureView object you want to bind.
    /// </summary>
    public TextureViewHandle TextureView;

    public BindGroupEntryFFI() { }

}
