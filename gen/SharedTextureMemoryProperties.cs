using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryProperties
{
	public ChainedStructOut* NextInChain;
	public TextureUsage Usage;
	public Extent3D Size;
	public TextureFormat Format;

	public SharedTextureMemoryProperties()
	{
		this.NextInChain = default;
		this.Usage = default;
		this.Size = default;
		this.Format = default;
	}

	public SharedTextureMemoryProperties(ChainedStructOut* nextInChain = default, TextureUsage usage = default, Extent3D size = default, TextureFormat format = default)
	{
		this.NextInChain = nextInChain;
		this.Usage = usage;
		this.Size = size;
		this.Format = format;
	}
}

