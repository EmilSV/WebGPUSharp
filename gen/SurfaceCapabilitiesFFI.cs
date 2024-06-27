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

    public SurfaceCapabilitiesFFI()
    {
    }


    public SurfaceCapabilitiesFFI(ChainedStructOut* nextInChain = default, TextureUsage usages = default, nuint formatCount = default, TextureFormat* formats = default, nuint presentModeCount = default, PresentMode* presentModes = default, nuint alphaModeCount = default, CompositeAlphaMode* alphaModes = default)
    {
        this.NextInChain = nextInChain;
        this.Usages = usages;
        this.FormatCount = formatCount;
        this.Formats = formats;
        this.PresentModeCount = presentModeCount;
        this.PresentModes = presentModes;
        this.AlphaModeCount = alphaModeCount;
        this.AlphaModes = alphaModes;
    }


    public SurfaceCapabilitiesFFI(TextureUsage usages = default, nuint formatCount = default, TextureFormat* formats = default, nuint presentModeCount = default, PresentMode* presentModes = default, nuint alphaModeCount = default, CompositeAlphaMode* alphaModes = default)
    {
        this.Usages = usages;
        this.FormatCount = formatCount;
        this.Formats = formats;
        this.PresentModeCount = presentModeCount;
        this.PresentModes = presentModes;
        this.AlphaModeCount = alphaModeCount;
        this.AlphaModes = alphaModes;
    }

}
