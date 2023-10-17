using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct Origin2D
{
	public uint X;
	public uint Y;

	public Origin2D()
	{
		this.X = default;
		this.Y = default;
	}

	public Origin2D(uint x = default, uint y = default)
	{
		this.X = x;
		this.Y = y;
	}
}

