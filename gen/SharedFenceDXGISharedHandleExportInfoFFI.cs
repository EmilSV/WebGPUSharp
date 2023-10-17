using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedFenceDXGISharedHandleExportInfoFFI
{
	public ChainedStructOut Chain;
	public void* Handle;

	public SharedFenceDXGISharedHandleExportInfoFFI()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceDXGISharedHandleExportInfoFFI(ChainedStructOut chain = default, void* handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

