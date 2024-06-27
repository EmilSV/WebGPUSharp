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

    public ExternalTextureDescriptorFFI()
    {
    }


    public ExternalTextureDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, TextureViewHandle plane0 = default, TextureViewHandle plane1 = default, Origin2D visibleOrigin = default, Extent2D visibleSize = default, WebGPUBool doYuvToRgbConversionOnly = default, float* yuvToRgbConversionMatrix = default, float* srcTransferFunctionParameters = default, float* dstTransferFunctionParameters = default, float* gamutConversionMatrix = default, WebGPUBool mirrored = default, ExternalTextureRotation rotation = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Plane0 = plane0;
        this.Plane1 = plane1;
        this.VisibleOrigin = visibleOrigin;
        this.VisibleSize = visibleSize;
        this.DoYuvToRgbConversionOnly = doYuvToRgbConversionOnly;
        this.YuvToRgbConversionMatrix = yuvToRgbConversionMatrix;
        this.SrcTransferFunctionParameters = srcTransferFunctionParameters;
        this.DstTransferFunctionParameters = dstTransferFunctionParameters;
        this.GamutConversionMatrix = gamutConversionMatrix;
        this.Mirrored = mirrored;
        this.Rotation = rotation;
    }


    public ExternalTextureDescriptorFFI(byte* label = default, TextureViewHandle plane0 = default, TextureViewHandle plane1 = default, Origin2D visibleOrigin = default, Extent2D visibleSize = default, WebGPUBool doYuvToRgbConversionOnly = default, float* yuvToRgbConversionMatrix = default, float* srcTransferFunctionParameters = default, float* dstTransferFunctionParameters = default, float* gamutConversionMatrix = default, WebGPUBool mirrored = default, ExternalTextureRotation rotation = default)
    {
        this.Label = label;
        this.Plane0 = plane0;
        this.Plane1 = plane1;
        this.VisibleOrigin = visibleOrigin;
        this.VisibleSize = visibleSize;
        this.DoYuvToRgbConversionOnly = doYuvToRgbConversionOnly;
        this.YuvToRgbConversionMatrix = yuvToRgbConversionMatrix;
        this.SrcTransferFunctionParameters = srcTransferFunctionParameters;
        this.DstTransferFunctionParameters = dstTransferFunctionParameters;
        this.GamutConversionMatrix = gamutConversionMatrix;
        this.Mirrored = mirrored;
        this.Rotation = rotation;
    }

}
