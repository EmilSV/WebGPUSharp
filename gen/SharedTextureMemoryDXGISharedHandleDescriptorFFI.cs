using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryDXGISharedHandleDescriptorFFI
{
	public ChainedStruct Chain;
	public void* Handle;

	public SharedTextureMemoryDXGISharedHandleDescriptorFFI()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedTextureMemoryDXGISharedHandleDescriptorFFI(ChainedStruct chain = default, void* handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

