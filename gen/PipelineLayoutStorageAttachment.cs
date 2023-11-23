using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct PipelineLayoutStorageAttachment
{
	public ChainedStruct* NextInChain;
	public ulong Offset;
	public TextureFormat Format;

	public PipelineLayoutStorageAttachment()
	{
		this.NextInChain = default;
		this.Offset = default;
		this.Format = default;
	}

	public PipelineLayoutStorageAttachment(ulong offset = default, TextureFormat format = default)
	{
		this.Offset = offset;
		this.Format = format;
	}

	public PipelineLayoutStorageAttachment(ChainedStruct* nextInChain = default, ulong offset = default, TextureFormat format = default)
	{
		this.NextInChain = nextInChain;
		this.Offset = offset;
		this.Format = format;
	}
}

