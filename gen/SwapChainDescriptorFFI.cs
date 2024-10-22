using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SwapChainDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public TextureUsage Usage;
    public TextureFormat Format;
    public uint Width;
    public uint Height;
    public PresentMode PresentMode;

    public SwapChainDescriptorFFI() { }

}
