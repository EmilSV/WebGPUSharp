using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes a single resource binding within a <see cref="BindGroupLayout" />.
/// </summary>
public unsafe partial struct BindGroupLayoutEntry
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
    /// A unique identifier for a resource binding within the  <see cref="BindGroupLayout"/>, corresponding
    /// to a  <see cref="BindGroupEntry.Binding">GPUBindGroupEntry.binding</see> and a @binding
    /// attribute in the  <see cref="ShaderModule"/>.
    /// </summary>
    public required uint Binding;
    /// <summary>
    /// A bitset of the members of  <see cref="ShaderStage"/>.
    /// Each set bit indicates that a  <see cref="BindGroupLayoutEntry"/>'s resource
    /// will be accessible from the associated shader stage.
    /// </summary>
    public required ShaderStage Visibility;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is BufferBinding.
    /// </summary>
    public BufferBindingLayout Buffer = default;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is  <see cref="WebGpuSharp.Sampler"/>.
    /// </summary>
    public SamplerBindingLayout Sampler = default;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is  <see cref="TextureView"/>.
    /// </summary>
    public TextureBindingLayout Texture = default;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is  <see cref="TextureView"/>.
    /// </summary>
    public StorageTextureBindingLayout StorageTexture;

    public BindGroupLayoutEntry() { }

}
