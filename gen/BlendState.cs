using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct BlendState
{
	public BlendComponent Color;
	public BlendComponent Alpha;

	public BlendState()
	{
		this.Color = default;
		this.Alpha = default;
	}

	public BlendState(BlendComponent color = default, BlendComponent alpha = default)
	{
		this.Color = color;
		this.Alpha = alpha;
	}
}

