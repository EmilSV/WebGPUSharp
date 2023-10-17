using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CopyTextureForBrowserOptionsFFI
{
	public ChainedStruct* NextInChain;
	public WGPUBool FlipY;
	public WGPUBool NeedsColorSpaceConversion;
	public AlphaMode SrcAlphaMode;
	public float* SrcTransferFunctionParameters;
	public float* ConversionMatrix;
	public float* DstTransferFunctionParameters;
	public AlphaMode DstAlphaMode;
	public WGPUBool InternalUsage;

	public CopyTextureForBrowserOptionsFFI()
	{
		this.NextInChain = default;
		this.FlipY = default;
		this.NeedsColorSpaceConversion = default;
		this.SrcAlphaMode = default;
		this.SrcTransferFunctionParameters = default;
		this.ConversionMatrix = default;
		this.DstTransferFunctionParameters = default;
		this.DstAlphaMode = default;
		this.InternalUsage = default;
	}

	public CopyTextureForBrowserOptionsFFI(WGPUBool flipY = default, WGPUBool needsColorSpaceConversion = default, AlphaMode srcAlphaMode = default, float* srcTransferFunctionParameters = default, float* conversionMatrix = default, float* dstTransferFunctionParameters = default, AlphaMode dstAlphaMode = default, WGPUBool internalUsage = default)
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

	public CopyTextureForBrowserOptionsFFI(ChainedStruct* nextInChain = default, WGPUBool flipY = default, WGPUBool needsColorSpaceConversion = default, AlphaMode srcAlphaMode = default, float* srcTransferFunctionParameters = default, float* conversionMatrix = default, float* dstTransferFunctionParameters = default, AlphaMode dstAlphaMode = default, WGPUBool internalUsage = default)
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
}

