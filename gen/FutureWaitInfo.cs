using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct FutureWaitInfo
{
	public Future Future;
	public WGPUBool Completed;

	public FutureWaitInfo()
	{
		this.Future = default;
		this.Completed = default;
	}

	public FutureWaitInfo(Future future = default, WGPUBool completed = default)
	{
		this.Future = future;
		this.Completed = completed;
	}
}

