using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedFenceVkSemaphoreOpaqueFDExportInfo
{
	public ChainedStructOut Chain;
	public int Handle;

	public SharedFenceVkSemaphoreOpaqueFDExportInfo()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceVkSemaphoreOpaqueFDExportInfo(ChainedStructOut chain = default, int handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

