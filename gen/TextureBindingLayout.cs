using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct TextureBindingLayout
{
	public ChainedStruct* NextInChain;
	public TextureSampleType SampleType;
	public TextureViewDimension ViewDimension;
	public WGPUBool Multisampled;

	public TextureBindingLayout()
	{
		this.NextInChain = default;
		this.SampleType = default;
		this.ViewDimension = default;
		this.Multisampled = default;
	}

	public TextureBindingLayout(TextureSampleType sampleType = default, TextureViewDimension viewDimension = default, WGPUBool multisampled = default)
	{
		this.SampleType = sampleType;
		this.ViewDimension = viewDimension;
		this.Multisampled = multisampled;
	}

	public TextureBindingLayout(ChainedStruct* nextInChain = default, TextureSampleType sampleType = default, TextureViewDimension viewDimension = default, WGPUBool multisampled = default)
	{
		this.NextInChain = nextInChain;
		this.SampleType = sampleType;
		this.ViewDimension = viewDimension;
		this.Multisampled = multisampled;
	}
}

