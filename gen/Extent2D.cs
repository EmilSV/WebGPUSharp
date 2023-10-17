using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct Extent2D
{
	public uint Width;
	public uint Height;

	public Extent2D()
	{
		this.Width = default;
		this.Height = default;
	}

	public Extent2D(uint width = default, uint height = default)
	{
		this.Width = width;
		this.Height = height;
	}
}

