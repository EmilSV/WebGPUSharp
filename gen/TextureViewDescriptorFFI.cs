using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureViewDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public TextureFormat Format;
    public TextureViewDimension Dimension;
    public uint BaseMipLevel = 0;
    public uint MipLevelCount;
    public uint BaseArrayLayer = 0;
    public uint ArrayLayerCount;
    public TextureAspect Aspect = TextureAspect.All;

    public TextureViewDescriptorFFI()
    {
    }

}
