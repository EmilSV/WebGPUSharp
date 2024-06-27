using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureViewDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public TextureFormat Format;
    public TextureViewDimension Dimension;
    public uint BaseMipLevel;
    public uint MipLevelCount;
    public uint BaseArrayLayer;
    public uint ArrayLayerCount;
    public TextureAspect Aspect;

    public TextureViewDescriptorFFI()
    {
    }


    public TextureViewDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, TextureFormat format = default, TextureViewDimension dimension = default, uint baseMipLevel = default, uint mipLevelCount = default, uint baseArrayLayer = default, uint arrayLayerCount = default, TextureAspect aspect = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Format = format;
        this.Dimension = dimension;
        this.BaseMipLevel = baseMipLevel;
        this.MipLevelCount = mipLevelCount;
        this.BaseArrayLayer = baseArrayLayer;
        this.ArrayLayerCount = arrayLayerCount;
        this.Aspect = aspect;
    }


    public TextureViewDescriptorFFI(byte* label = default, TextureFormat format = default, TextureViewDimension dimension = default, uint baseMipLevel = default, uint mipLevelCount = default, uint baseArrayLayer = default, uint arrayLayerCount = default, TextureAspect aspect = default)
    {
        this.Label = label;
        this.Format = format;
        this.Dimension = dimension;
        this.BaseMipLevel = baseMipLevel;
        this.MipLevelCount = mipLevelCount;
        this.BaseArrayLayer = baseArrayLayer;
        this.ArrayLayerCount = arrayLayerCount;
        this.Aspect = aspect;
    }

}
