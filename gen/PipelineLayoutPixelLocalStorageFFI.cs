using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct PipelineLayoutPixelLocalStorageFFI
{
	public ChainedStruct Chain;
	public ulong TotalPixelLocalStorageSize;
	public nuint StorageAttachmentCount;
	public PipelineLayoutStorageAttachment* StorageAttachments;

	public PipelineLayoutPixelLocalStorageFFI()
	{
		this.Chain = default;
		this.TotalPixelLocalStorageSize = default;
		this.StorageAttachmentCount = default;
		this.StorageAttachments = default;
	}

	public PipelineLayoutPixelLocalStorageFFI(ChainedStruct chain = default, ulong totalPixelLocalStorageSize = default, nuint storageAttachmentCount = default, PipelineLayoutStorageAttachment* storageAttachments = default)
	{
		this.Chain = chain;
		this.TotalPixelLocalStorageSize = totalPixelLocalStorageSize;
		this.StorageAttachmentCount = storageAttachmentCount;
		this.StorageAttachments = storageAttachments;
	}
}

