using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceCapabilitiesFFI
{
    public ChainedStructOut* NextInChain;
    public TextureUsage Usages;
    public nuint FormatCount;
    public TextureFormat* Formats;
    public nuint PresentModeCount;
    public PresentMode* PresentModes;
    public nuint AlphaModeCount;
    public CompositeAlphaMode* AlphaModes;

    public SurfaceCapabilitiesFFI() { }

}
