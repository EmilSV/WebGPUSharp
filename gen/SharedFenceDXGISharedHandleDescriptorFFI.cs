using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedFenceDXGISharedHandleDescriptorFFI
{
	public ChainedStruct Chain;
	public void* Handle;

	public SharedFenceDXGISharedHandleDescriptorFFI()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceDXGISharedHandleDescriptorFFI(ChainedStruct chain = default, void* handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

