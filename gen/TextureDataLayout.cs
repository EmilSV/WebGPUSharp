using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct TextureDataLayout
{
	public ChainedStruct* NextInChain;
	public ulong Offset;
	public uint BytesPerRow;
	public uint RowsPerImage;

	public TextureDataLayout()
	{
		this.NextInChain = default;
		this.Offset = default;
		this.BytesPerRow = default;
		this.RowsPerImage = default;
	}

	public TextureDataLayout(ulong offset = default, uint bytesPerRow = default, uint rowsPerImage = default)
	{
		this.Offset = offset;
		this.BytesPerRow = bytesPerRow;
		this.RowsPerImage = rowsPerImage;
	}

	public TextureDataLayout(ChainedStruct* nextInChain = default, ulong offset = default, uint bytesPerRow = default, uint rowsPerImage = default)
	{
		this.NextInChain = nextInChain;
		this.Offset = offset;
		this.BytesPerRow = bytesPerRow;
		this.RowsPerImage = rowsPerImage;
	}
}

