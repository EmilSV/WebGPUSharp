using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceConfigurationFFI
{
    public ChainedStruct* NextInChain;
    public DeviceHandle Device;
    public TextureFormat Format;
    public TextureUsage Usage;
    public nuint ViewFormatCount;
    public TextureFormat* ViewFormats;
    public CompositeAlphaMode AlphaMode;
    public uint Width;
    public uint Height;
    public PresentMode PresentMode;

    public SurfaceConfigurationFFI()
    {
    }


    public SurfaceConfigurationFFI(ChainedStruct* nextInChain = default, DeviceHandle device = default, TextureFormat format = default, TextureUsage usage = default, nuint viewFormatCount = default, TextureFormat* viewFormats = default, CompositeAlphaMode alphaMode = default, uint width = default, uint height = default, PresentMode presentMode = default)
    {
        this.NextInChain = nextInChain;
        this.Device = device;
        this.Format = format;
        this.Usage = usage;
        this.ViewFormatCount = viewFormatCount;
        this.ViewFormats = viewFormats;
        this.AlphaMode = alphaMode;
        this.Width = width;
        this.Height = height;
        this.PresentMode = presentMode;
    }


    public SurfaceConfigurationFFI(DeviceHandle device = default, TextureFormat format = default, TextureUsage usage = default, nuint viewFormatCount = default, TextureFormat* viewFormats = default, CompositeAlphaMode alphaMode = default, uint width = default, uint height = default, PresentMode presentMode = default)
    {
        this.Device = device;
        this.Format = format;
        this.Usage = usage;
        this.ViewFormatCount = viewFormatCount;
        this.ViewFormats = viewFormats;
        this.AlphaMode = alphaMode;
        this.Width = width;
        this.Height = height;
        this.PresentMode = presentMode;
    }

}
