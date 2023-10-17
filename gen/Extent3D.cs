using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct Extent3D
{
	public uint Width;
	public uint Height;
	public uint DepthOrArrayLayers;

	public Extent3D()
	{
		this.Width = default;
		this.Height = default;
		this.DepthOrArrayLayers = default;
	}

	public Extent3D(uint width = default, uint height = default, uint depthOrArrayLayers = default)
	{
		this.Width = width;
		this.Height = height;
		this.DepthOrArrayLayers = depthOrArrayLayers;
	}
}

