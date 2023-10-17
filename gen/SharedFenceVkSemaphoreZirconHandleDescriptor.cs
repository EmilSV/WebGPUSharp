using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedFenceVkSemaphoreZirconHandleDescriptor
{
	public ChainedStruct Chain;
	public uint Handle;

	public SharedFenceVkSemaphoreZirconHandleDescriptor()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceVkSemaphoreZirconHandleDescriptor(ChainedStruct chain = default, uint handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

