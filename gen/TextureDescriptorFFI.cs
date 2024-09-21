using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public required TextureUsage Usage;
    public TextureDimension Dimension = TextureDimension.D2;
    public required Extent3D Size;
    public required TextureFormat Format;
    public uint MipLevelCount = 1;
    public uint SampleCount = 1;
    public nuint ViewFormatCount;
    public TextureFormat* ViewFormats;

    public TextureDescriptorFFI()
    {
    }

}
