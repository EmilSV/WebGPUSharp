using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct BindGroupLayoutEntry
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A unique identifier for a resource binding within the  <see cref="WebGpuSharp.BindGroupLayout"/>, corresponding
    /// to a  <see cref="WebGpuSharp.BindGroupEntry.Binding">GPUBindGroupEntry.binding</see> and a @binding
    /// attribute in the  <see cref="WebGpuSharp.ShaderModule"/>.
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
    public BufferBindingLayout Buffer;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is  <see cref="WebGpuSharp.Sampler"/>.
    /// </summary>
    public SamplerBindingLayout Sampler;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is  <see cref="WebGpuSharp.TextureView"/>.
    /// </summary>
    public TextureBindingLayout Texture;
    /// <summary>
    /// When provided, indicates the binding resource type for this  <see cref="BindGroupLayoutEntry"/>
    /// is  <see cref="WebGpuSharp.TextureView"/>.
    /// </summary>
    public StorageTextureBindingLayout StorageTexture;

    public BindGroupLayoutEntry() { }

}
