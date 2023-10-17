using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ImageCopyExternalTextureFFI
{
	public ChainedStruct* NextInChain;
	public ExternalTextureHandle ExternalTexture;
	public Origin3D Origin;
	public Extent2D NaturalSize;

	public ImageCopyExternalTextureFFI()
	{
		this.NextInChain = default;
		this.ExternalTexture = default;
		this.Origin = default;
		this.NaturalSize = default;
	}

	public ImageCopyExternalTextureFFI(ExternalTextureHandle externalTexture = default, Origin3D origin = default, Extent2D naturalSize = default)
	{
		this.ExternalTexture = externalTexture;
		this.Origin = origin;
		this.NaturalSize = naturalSize;
	}

	public ImageCopyExternalTextureFFI(ChainedStruct* nextInChain = default, ExternalTextureHandle externalTexture = default, Origin3D origin = default, Extent2D naturalSize = default)
	{
		this.NextInChain = nextInChain;
		this.ExternalTexture = externalTexture;
		this.Origin = origin;
		this.NaturalSize = naturalSize;
	}
}

