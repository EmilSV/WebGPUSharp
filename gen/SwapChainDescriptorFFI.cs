using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SwapChainDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public TextureUsage Usage;
	public TextureFormat Format;
	public uint Width;
	public uint Height;
	public PresentMode PresentMode;

	public SwapChainDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Usage = default;
		this.Format = default;
		this.Width = default;
		this.Height = default;
		this.PresentMode = default;
	}

	public SwapChainDescriptorFFI(byte* label = default, TextureUsage usage = default, TextureFormat format = default, uint width = default, uint height = default, PresentMode presentMode = default)
	{
		this.Label = label;
		this.Usage = usage;
		this.Format = format;
		this.Width = width;
		this.Height = height;
		this.PresentMode = presentMode;
	}

	public SwapChainDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, TextureUsage usage = default, TextureFormat format = default, uint width = default, uint height = default, PresentMode presentMode = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.Usage = usage;
		this.Format = format;
		this.Width = width;
		this.Height = height;
		this.PresentMode = presentMode;
	}
}

