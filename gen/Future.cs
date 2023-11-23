using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct Future
{
	public ulong Id;

	public Future()
	{
		this.Id = default;
	}

	public Future(ulong id = default)
	{
		this.Id = id;
	}
}

