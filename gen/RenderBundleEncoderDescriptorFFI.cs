using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RenderBundleEncoderDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public nuint ColorFormatCount;
	public TextureFormat* ColorFormats;
	public TextureFormat DepthStencilFormat;
	public uint SampleCount;
	public WGPUBool DepthReadOnly;
	public WGPUBool StencilReadOnly;

	public RenderBundleEncoderDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.ColorFormatCount = default;
		this.ColorFormats = default;
		this.DepthStencilFormat = default;
		this.SampleCount = default;
		this.DepthReadOnly = default;
		this.StencilReadOnly = default;
	}

	public RenderBundleEncoderDescriptorFFI(byte* label = default, nuint colorFormatCount = default, TextureFormat* colorFormats = default, TextureFormat depthStencilFormat = default, uint sampleCount = default, WGPUBool depthReadOnly = default, WGPUBool stencilReadOnly = default)
	{
		this.Label = label;
		this.ColorFormatCount = colorFormatCount;
		this.ColorFormats = colorFormats;
		this.DepthStencilFormat = depthStencilFormat;
		this.SampleCount = sampleCount;
		this.DepthReadOnly = depthReadOnly;
		this.StencilReadOnly = stencilReadOnly;
	}

	public RenderBundleEncoderDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint colorFormatCount = default, TextureFormat* colorFormats = default, TextureFormat depthStencilFormat = default, uint sampleCount = default, WGPUBool depthReadOnly = default, WGPUBool stencilReadOnly = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.ColorFormatCount = colorFormatCount;
		this.ColorFormats = colorFormats;
		this.DepthStencilFormat = depthStencilFormat;
		this.SampleCount = sampleCount;
		this.DepthReadOnly = depthReadOnly;
		this.StencilReadOnly = stencilReadOnly;
	}
}

