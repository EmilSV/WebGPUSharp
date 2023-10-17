using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedFenceVkSemaphoreZirconHandleExportInfo
{
	public ChainedStructOut Chain;
	public uint Handle;

	public SharedFenceVkSemaphoreZirconHandleExportInfo()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceVkSemaphoreZirconHandleExportInfo(ChainedStructOut chain = default, uint handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

