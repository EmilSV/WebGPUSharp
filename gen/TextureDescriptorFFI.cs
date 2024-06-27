using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public TextureUsage Usage;
    public TextureDimension Dimension;
    public Extent3D Size;
    public TextureFormat Format;
    public uint MipLevelCount;
    public uint SampleCount;
    public nuint ViewFormatCount;
    public TextureFormat* ViewFormats;

    public TextureDescriptorFFI()
    {
    }


    public TextureDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, TextureUsage usage = default, TextureDimension dimension = default, Extent3D size = default, TextureFormat format = default, uint mipLevelCount = default, uint sampleCount = default, nuint viewFormatCount = default, TextureFormat* viewFormats = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Usage = usage;
        this.Dimension = dimension;
        this.Size = size;
        this.Format = format;
        this.MipLevelCount = mipLevelCount;
        this.SampleCount = sampleCount;
        this.ViewFormatCount = viewFormatCount;
        this.ViewFormats = viewFormats;
    }


    public TextureDescriptorFFI(byte* label = default, TextureUsage usage = default, TextureDimension dimension = default, Extent3D size = default, TextureFormat format = default, uint mipLevelCount = default, uint sampleCount = default, nuint viewFormatCount = default, TextureFormat* viewFormats = default)
    {
        this.Label = label;
        this.Usage = usage;
        this.Dimension = dimension;
        this.Size = size;
        this.Format = format;
        this.MipLevelCount = mipLevelCount;
        this.SampleCount = sampleCount;
        this.ViewFormatCount = viewFormatCount;
        this.ViewFormats = viewFormats;
    }

}
