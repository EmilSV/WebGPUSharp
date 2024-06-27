using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct YCbCrVkDescriptor
{
    public ChainedStruct Chain;
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
    public WebGPUBool ForceExplicitReconstruction;
    public ulong ExternalFormat;

    public YCbCrVkDescriptor()
    {
    }


    public YCbCrVkDescriptor(ChainedStruct chain = default, uint vkFormat = default, uint vkYCbCrModel = default, uint vkYCbCrRange = default, uint vkComponentSwizzleRed = default, uint vkComponentSwizzleGreen = default, uint vkComponentSwizzleBlue = default, uint vkComponentSwizzleAlpha = default, uint vkXChromaOffset = default, uint vkYChromaOffset = default, FilterMode vkChromaFilter = default, WebGPUBool forceExplicitReconstruction = default, ulong externalFormat = default)
    {
        this.Chain = chain;
        this.VkFormat = vkFormat;
        this.VkYCbCrModel = vkYCbCrModel;
        this.VkYCbCrRange = vkYCbCrRange;
        this.VkComponentSwizzleRed = vkComponentSwizzleRed;
        this.VkComponentSwizzleGreen = vkComponentSwizzleGreen;
        this.VkComponentSwizzleBlue = vkComponentSwizzleBlue;
        this.VkComponentSwizzleAlpha = vkComponentSwizzleAlpha;
        this.VkXChromaOffset = vkXChromaOffset;
        this.VkYChromaOffset = vkYChromaOffset;
        this.VkChromaFilter = vkChromaFilter;
        this.ForceExplicitReconstruction = forceExplicitReconstruction;
        this.ExternalFormat = externalFormat;
    }

}
