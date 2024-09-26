using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct BindGroupLayoutEntry
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A unique identifier for a resource binding within the <see cref="FFI.BindGroupLayout"/>, corresponding
    /// to a <see cref="FFI.BindGroupEntry.Binding">GPUBindGroupEntry.binding</see>and a@bindingattribute in the <see cref="FFI.ShaderModule"/>.
    /// </summary>
    public required uint Binding;
    /// <summary>
    /// A bitset of the members of <see cref="ShaderStage"/>.
    /// Each set bit indicates that a <see cref="BindGroupLayoutEntry"/>'s resource
    /// will be accessible from the associated shader stage.
    /// </summary>
    public required ShaderStage Visibility;
    /// <summary>
    /// Whenprovided, indicates thebinding resource typefor this <see cref="BindGroupLayoutEntry"/>isBufferBinding.
    /// </summary>
    public BufferBindingLayout Buffer;
    /// <summary>
    /// Whenprovided, indicates thebinding resource typefor this <see cref="BindGroupLayoutEntry"/>is <see cref="FFI.Sampler"/>.
    /// </summary>
    public SamplerBindingLayout Sampler;
    /// <summary>
    /// Whenprovided, indicates thebinding resource typefor this <see cref="BindGroupLayoutEntry"/>is <see cref="FFI.TextureView"/>.
    /// </summary>
    public TextureBindingLayout Texture;
    /// <summary>
    /// Whenprovided, indicates thebinding resource typefor this <see cref="BindGroupLayoutEntry"/>is <see cref="FFI.TextureView"/>.
    /// </summary>
    public StorageTextureBindingLayout StorageTexture;

    public BindGroupLayoutEntry()
    {
    }

}
