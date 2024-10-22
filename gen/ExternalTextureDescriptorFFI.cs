using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ExternalTextureDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public TextureViewHandle Plane0;
    public TextureViewHandle Plane1;
    public Origin2D VisibleOrigin;
    public Extent2D VisibleSize;
    public WebGPUBool DoYuvToRgbConversionOnly;
    public float* YuvToRgbConversionMatrix;
    public float* SrcTransferFunctionParameters;
    public float* DstTransferFunctionParameters;
    public float* GamutConversionMatrix;
    public WebGPUBool Mirrored;
    public ExternalTextureRotation Rotation;

    public ExternalTextureDescriptorFFI() { }

}
