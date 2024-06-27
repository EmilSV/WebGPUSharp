using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SamplerDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public AddressMode AddressModeU;
    public AddressMode AddressModeV;
    public AddressMode AddressModeW;
    public FilterMode MagFilter;
    public FilterMode MinFilter;
    public MipmapFilterMode MipmapFilter;
    public float LodMinClamp;
    public float LodMaxClamp;
    public CompareFunction Compare;
    public ushort MaxAnisotropy;

    public SamplerDescriptorFFI()
    {
    }


    public SamplerDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, AddressMode addressModeU = default, AddressMode addressModeV = default, AddressMode addressModeW = default, FilterMode magFilter = default, FilterMode minFilter = default, MipmapFilterMode mipmapFilter = default, float lodMinClamp = default, float lodMaxClamp = default, CompareFunction compare = default, ushort maxAnisotropy = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.AddressModeU = addressModeU;
        this.AddressModeV = addressModeV;
        this.AddressModeW = addressModeW;
        this.MagFilter = magFilter;
        this.MinFilter = minFilter;
        this.MipmapFilter = mipmapFilter;
        this.LodMinClamp = lodMinClamp;
        this.LodMaxClamp = lodMaxClamp;
        this.Compare = compare;
        this.MaxAnisotropy = maxAnisotropy;
    }


    public SamplerDescriptorFFI(byte* label = default, AddressMode addressModeU = default, AddressMode addressModeV = default, AddressMode addressModeW = default, FilterMode magFilter = default, FilterMode minFilter = default, MipmapFilterMode mipmapFilter = default, float lodMinClamp = default, float lodMaxClamp = default, CompareFunction compare = default, ushort maxAnisotropy = default)
    {
        this.Label = label;
        this.AddressModeU = addressModeU;
        this.AddressModeV = addressModeV;
        this.AddressModeW = addressModeW;
        this.MagFilter = magFilter;
        this.MinFilter = minFilter;
        this.MipmapFilter = mipmapFilter;
        this.LodMinClamp = lodMinClamp;
        this.LodMaxClamp = lodMaxClamp;
        this.Compare = compare;
        this.MaxAnisotropy = maxAnisotropy;
    }

}
