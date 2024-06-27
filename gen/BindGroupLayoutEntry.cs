using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct BindGroupLayoutEntry
{
    public ChainedStruct* NextInChain;
    public uint Binding;
    public ShaderStage Visibility;
    public BufferBindingLayout Buffer;
    public SamplerBindingLayout Sampler;
    public TextureBindingLayout Texture;
    public StorageTextureBindingLayout StorageTexture;

    public BindGroupLayoutEntry()
    {
    }


    public BindGroupLayoutEntry(ChainedStruct* nextInChain = default, uint binding = default, ShaderStage visibility = default, BufferBindingLayout buffer = default, SamplerBindingLayout sampler = default, TextureBindingLayout texture = default, StorageTextureBindingLayout storageTexture = default)
    {
        this.NextInChain = nextInChain;
        this.Binding = binding;
        this.Visibility = visibility;
        this.Buffer = buffer;
        this.Sampler = sampler;
        this.Texture = texture;
        this.StorageTexture = storageTexture;
    }


    public BindGroupLayoutEntry(uint binding = default, ShaderStage visibility = default, BufferBindingLayout buffer = default, SamplerBindingLayout sampler = default, TextureBindingLayout texture = default, StorageTextureBindingLayout storageTexture = default)
    {
        this.Binding = binding;
        this.Visibility = visibility;
        this.Buffer = buffer;
        this.Sampler = sampler;
        this.Texture = texture;
        this.StorageTexture = storageTexture;
    }

}
