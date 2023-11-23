using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RenderPassPixelLocalStorageFFI
{
	public ChainedStruct Chain;
	public ulong TotalPixelLocalStorageSize;
	public nuint StorageAttachmentCount;
	public RenderPassStorageAttachmentFFI* StorageAttachments;

	public RenderPassPixelLocalStorageFFI()
	{
		this.Chain = default;
		this.TotalPixelLocalStorageSize = default;
		this.StorageAttachmentCount = default;
		this.StorageAttachments = default;
	}

	public RenderPassPixelLocalStorageFFI(ChainedStruct chain = default, ulong totalPixelLocalStorageSize = default, nuint storageAttachmentCount = default, RenderPassStorageAttachmentFFI* storageAttachments = default)
	{
		this.Chain = chain;
		this.TotalPixelLocalStorageSize = totalPixelLocalStorageSize;
		this.StorageAttachmentCount = storageAttachmentCount;
		this.StorageAttachments = storageAttachments;
	}
}

