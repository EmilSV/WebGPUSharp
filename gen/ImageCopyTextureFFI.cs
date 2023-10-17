using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ImageCopyTextureFFI
{
	public ChainedStruct* NextInChain;
	public TextureHandle Texture;
	public uint MipLevel;
	public Origin3D Origin;
	public TextureAspect Aspect;

	public ImageCopyTextureFFI()
	{
		this.NextInChain = default;
		this.Texture = default;
		this.MipLevel = default;
		this.Origin = default;
		this.Aspect = default;
	}

	public ImageCopyTextureFFI(TextureHandle texture = default, uint mipLevel = default, Origin3D origin = default, TextureAspect aspect = default)
	{
		this.Texture = texture;
		this.MipLevel = mipLevel;
		this.Origin = origin;
		this.Aspect = aspect;
	}

	public ImageCopyTextureFFI(ChainedStruct* nextInChain = default, TextureHandle texture = default, uint mipLevel = default, Origin3D origin = default, TextureAspect aspect = default)
	{
		this.NextInChain = nextInChain;
		this.Texture = texture;
		this.MipLevel = mipLevel;
		this.Origin = origin;
		this.Aspect = aspect;
	}
}

