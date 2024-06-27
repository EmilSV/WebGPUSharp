using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SharedTextureMemoryProperties
{
    public ChainedStructOut* NextInChain;
    public TextureUsage Usage;
    public Extent3D Size;
    public TextureFormat Format;

    public SharedTextureMemoryProperties()
    {
    }


    public SharedTextureMemoryProperties(ChainedStructOut* nextInChain = default, TextureUsage usage = default, Extent3D size = default, TextureFormat format = default)
    {
        this.NextInChain = nextInChain;
        this.Usage = usage;
        this.Size = size;
        this.Format = format;
    }


    public SharedTextureMemoryProperties(TextureUsage usage = default, Extent3D size = default, TextureFormat format = default)
    {
        this.Usage = usage;
        this.Size = size;
        this.Format = format;
    }

}
