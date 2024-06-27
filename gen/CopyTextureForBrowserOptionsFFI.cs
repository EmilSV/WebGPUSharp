using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CopyTextureForBrowserOptionsFFI
{
    public ChainedStruct* NextInChain;
    public WebGPUBool FlipY;
    public WebGPUBool NeedsColorSpaceConversion;
    public AlphaMode SrcAlphaMode;
    public float* SrcTransferFunctionParameters;
    public float* ConversionMatrix;
    public float* DstTransferFunctionParameters;
    public AlphaMode DstAlphaMode;
    public WebGPUBool InternalUsage;

    public CopyTextureForBrowserOptionsFFI()
    {
    }


    public CopyTextureForBrowserOptionsFFI(ChainedStruct* nextInChain = default, WebGPUBool flipY = default, WebGPUBool needsColorSpaceConversion = default, AlphaMode srcAlphaMode = default, float* srcTransferFunctionParameters = default, float* conversionMatrix = default, float* dstTransferFunctionParameters = default, AlphaMode dstAlphaMode = default, WebGPUBool internalUsage = default)
    {
        this.NextInChain = nextInChain;
        this.FlipY = flipY;
        this.NeedsColorSpaceConversion = needsColorSpaceConversion;
        this.SrcAlphaMode = srcAlphaMode;
        this.SrcTransferFunctionParameters = srcTransferFunctionParameters;
        this.ConversionMatrix = conversionMatrix;
        this.DstTransferFunctionParameters = dstTransferFunctionParameters;
        this.DstAlphaMode = dstAlphaMode;
        this.InternalUsage = internalUsage;
    }


    public CopyTextureForBrowserOptionsFFI(WebGPUBool flipY = default, WebGPUBool needsColorSpaceConversion = default, AlphaMode srcAlphaMode = default, float* srcTransferFunctionParameters = default, float* conversionMatrix = default, float* dstTransferFunctionParameters = default, AlphaMode dstAlphaMode = default, WebGPUBool internalUsage = default)
    {
        this.FlipY = flipY;
        this.NeedsColorSpaceConversion = needsColorSpaceConversion;
        this.SrcAlphaMode = srcAlphaMode;
        this.SrcTransferFunctionParameters = srcTransferFunctionParameters;
        this.ConversionMatrix = conversionMatrix;
        this.DstTransferFunctionParameters = dstTransferFunctionParameters;
        this.DstAlphaMode = dstAlphaMode;
        this.InternalUsage = internalUsage;
    }

}
