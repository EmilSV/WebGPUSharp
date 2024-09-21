using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct BindGroupLayoutEntry
{
    public ChainedStruct* NextInChain;
    public required uint Binding;
    public required ShaderStage Visibility;
    public BufferBindingLayout Buffer;
    public SamplerBindingLayout Sampler;
    public TextureBindingLayout Texture;
    public StorageTextureBindingLayout StorageTexture;

    public BindGroupLayoutEntry()
    {
    }

}
