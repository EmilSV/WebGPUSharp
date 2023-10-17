using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct Origin3D
{
	public uint X;
	public uint Y;
	public uint Z;

	public Origin3D()
	{
		this.X = default;
		this.Y = default;
		this.Z = default;
	}

	public Origin3D(uint x = default, uint y = default, uint z = default)
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
	}
}

