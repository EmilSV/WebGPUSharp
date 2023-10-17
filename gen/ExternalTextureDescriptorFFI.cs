using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ExternalTextureDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public TextureViewHandle Plane0;
	public TextureViewHandle Plane1;
	public Origin2D VisibleOrigin;
	public Extent2D VisibleSize;
	public WGPUBool DoYuvToRgbConversionOnly;
	public float* YuvToRgbConversionMatrix;
	public float* SrcTransferFunctionParameters;
	public float* DstTransferFunctionParameters;
	public float* GamutConversionMatrix;
	public WGPUBool FlipY;
	public ExternalTextureRotation Rotation;

	public ExternalTextureDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Plane0 = default;
		this.Plane1 = default;
		this.VisibleOrigin = default;
		this.VisibleSize = default;
		this.DoYuvToRgbConversionOnly = default;
		this.YuvToRgbConversionMatrix = default;
		this.SrcTransferFunctionParameters = default;
		this.DstTransferFunctionParameters = default;
		this.GamutConversionMatrix = default;
		this.FlipY = default;
		this.Rotation = default;
	}

	public ExternalTextureDescriptorFFI(byte* label = default, TextureViewHandle plane0 = default, TextureViewHandle plane1 = default, Origin2D visibleOrigin = default, Extent2D visibleSize = default, WGPUBool doYuvToRgbConversionOnly = default, float* yuvToRgbConversionMatrix = default, float* srcTransferFunctionParameters = default, float* dstTransferFunctionParameters = default, float* gamutConversionMatrix = default, WGPUBool flipY = default, ExternalTextureRotation rotation = default)
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
		this.FlipY = flipY;
		this.Rotation = rotation;
	}

	public ExternalTextureDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, TextureViewHandle plane0 = default, TextureViewHandle plane1 = default, Origin2D visibleOrigin = default, Extent2D visibleSize = default, WGPUBool doYuvToRgbConversionOnly = default, float* yuvToRgbConversionMatrix = default, float* srcTransferFunctionParameters = default, float* dstTransferFunctionParameters = default, float* gamutConversionMatrix = default, WGPUBool flipY = default, ExternalTextureRotation rotation = default)
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
		this.FlipY = flipY;
		this.Rotation = rotation;
	}
}

