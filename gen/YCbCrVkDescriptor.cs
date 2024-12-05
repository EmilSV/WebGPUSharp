using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct YCbCrVkDescriptor
{
    public ChainedStruct Chain = new();
    public uint VkFormat;
    public uint VkYCbCrModel;
    public uint VkYCbCrRange;
    public uint VkComponentSwizzleRed;
    public uint VkComponentSwizzleGreen;
    public uint VkComponentSwizzleBlue;
    public uint VkComponentSwizzleAlpha;
    public uint VkXChromaOffset;
    public uint VkYChromaOffset;
    public FilterMode VkChromaFilter;
    public WebGPUBool ForceExplicitReconstruction = new();
    public ulong ExternalFormat;

    public YCbCrVkDescriptor() { }

}
