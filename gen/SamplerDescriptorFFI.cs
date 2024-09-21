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


    public SamplerDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, AddressMode addressModeU = AddressMode.ClampToEdge, AddressMode addressModeV = AddressMode.ClampToEdge, AddressMode addressModeW = AddressMode.ClampToEdge, FilterMode magFilter = FilterMode.Nearest, FilterMode minFilter = FilterMode.Nearest, MipmapFilterMode mipmapFilter = MipmapFilterMode.Nearest, float lodMinClamp = 0, float lodMaxClamp = 32, CompareFunction compare = default, ushort maxAnisotropy = 1)
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


    public SamplerDescriptorFFI(byte* label = default, AddressMode addressModeU = AddressMode.ClampToEdge, AddressMode addressModeV = AddressMode.ClampToEdge, AddressMode addressModeW = AddressMode.ClampToEdge, FilterMode magFilter = FilterMode.Nearest, FilterMode minFilter = FilterMode.Nearest, MipmapFilterMode mipmapFilter = MipmapFilterMode.Nearest, float lodMinClamp = 0, float lodMaxClamp = 32, CompareFunction compare = default, ushort maxAnisotropy = 1)
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
