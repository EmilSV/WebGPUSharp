using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ExternalTextureDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = new();
    public TextureViewHandle Plane0;
    public TextureViewHandle Plane1;
    public Origin2D CropOrigin = new();
    public Extent2D CropSize = new();
    public Extent2D ApparentSize = new();
    public WebGPUBool DoYuvToRgbConversionOnly = new();
    public float* YuvToRgbConversionMatrix;
    public float* SrcTransferFunctionParameters;
    public float* DstTransferFunctionParameters;
    public float* GamutConversionMatrix;
    public WebGPUBool Mirrored = new();
    public ExternalTextureRotation Rotation;

    public ExternalTextureDescriptorFFI() { }

}
