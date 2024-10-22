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

    public CopyTextureForBrowserOptionsFFI() { }

}
