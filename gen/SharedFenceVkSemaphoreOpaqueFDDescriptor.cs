using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedFenceVkSemaphoreOpaqueFDDescriptor
{
	public ChainedStruct Chain;
	public int Handle;

	public SharedFenceVkSemaphoreOpaqueFDDescriptor()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedFenceVkSemaphoreOpaqueFDDescriptor(ChainedStruct chain = default, int handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

