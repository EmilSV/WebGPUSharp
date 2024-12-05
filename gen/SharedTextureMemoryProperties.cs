using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SharedTextureMemoryProperties
{
    public ChainedStructOut* NextInChain;
    public TextureUsage Usage;
    public Extent3D Size = new();
    public TextureFormat Format;

    public SharedTextureMemoryProperties() { }

}
