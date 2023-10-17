using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedFenceVkSemaphoreSyncFDDescriptor
{
	public ChainedStruct Chain;
	public int Handle;

	public SharedFenceVkSemaphoreSyncFDDescriptor()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceVkSemaphoreSyncFDDescriptor(ChainedStruct chain = default, int handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

