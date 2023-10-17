using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct BlendComponent
{
	public BlendOperation Operation;
	public BlendFactor SrcFactor;
	public BlendFactor DstFactor;

	public BlendComponent()
	{
		this.Operation = default;
		this.SrcFactor = default;
		this.DstFactor = default;
	}

	public BlendComponent(BlendOperation operation = default, BlendFactor srcFactor = default, BlendFactor dstFactor = default)
	{
		this.Operation = operation;
		this.SrcFactor = srcFactor;
		this.DstFactor = dstFactor;
	}
}

