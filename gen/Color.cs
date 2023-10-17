using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct Color
{
	public double R;
	public double G;
	public double B;
	public double A;

	public Color()
	{
		this.R = default;
		this.G = default;
		this.B = default;
		this.A = default;
	}

	public Color(double r = default, double g = default, double b = default, double a = default)
	{
		this.R = r;
		this.G = g;
		this.B = b;
		this.A = a;
	}
}

