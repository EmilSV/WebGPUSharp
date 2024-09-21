using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SamplerDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public AddressMode AddressModeU = AddressMode.ClampToEdge;
    public AddressMode AddressModeV = AddressMode.ClampToEdge;
    public AddressMode AddressModeW = AddressMode.ClampToEdge;
    public FilterMode MagFilter = FilterMode.Nearest;
    public FilterMode MinFilter = FilterMode.Nearest;
    public MipmapFilterMode MipmapFilter = MipmapFilterMode.Nearest;
    public float LodMinClamp = 0;
    public float LodMaxClamp = 32;
    public CompareFunction Compare;
    public ushort MaxAnisotropy = 1;

    public SamplerDescriptorFFI()
    {
    }

}
