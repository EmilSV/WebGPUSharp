using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedFenceExportInfo
{
	public ChainedStructOut* NextInChain;
	public SharedFenceType Type;

	public SharedFenceExportInfo()
	{
		this.NextInChain = default;
		this.Type = default;
	}

	public SharedFenceExportInfo(ChainedStructOut* nextInChain = default, SharedFenceType type = default)
	{
		this.NextInChain = nextInChain;
		this.Type = type;
	}
}

