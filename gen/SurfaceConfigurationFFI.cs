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

}
