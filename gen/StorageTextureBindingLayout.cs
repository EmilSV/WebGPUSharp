using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct StorageTextureBindingLayout
{
	public ChainedStruct* NextInChain;
	public StorageTextureAccess Access;
	public TextureFormat Format;
	public TextureViewDimension ViewDimension;

	public StorageTextureBindingLayout()
	{
		this.NextInChain = default;
		this.Access = default;
		this.Format = default;
		this.ViewDimension = default;
	}

	public StorageTextureBindingLayout(StorageTextureAccess access = default, TextureFormat format = default, TextureViewDimension viewDimension = default)
	{
		this.Access = access;
		this.Format = format;
		this.ViewDimension = viewDimension;
	}

	public StorageTextureBindingLayout(ChainedStruct* nextInChain = default, StorageTextureAccess access = default, TextureFormat format = default, TextureViewDimension viewDimension = default)
	{
		this.NextInChain = nextInChain;
		this.Access = access;
		this.Format = format;
		this.ViewDimension = viewDimension;
	}
}

