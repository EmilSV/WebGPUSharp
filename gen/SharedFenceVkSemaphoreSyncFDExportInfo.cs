using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedFenceVkSemaphoreSyncFDExportInfo
{
	public ChainedStructOut Chain;
	public int Handle;

	public SharedFenceVkSemaphoreSyncFDExportInfo()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceVkSemaphoreSyncFDExportInfo(ChainedStructOut chain = default, int handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

