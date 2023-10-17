using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromWaylandSurfaceFFI
{
	public ChainedStruct Chain;
	public void* Display;
	public void* Surface;

	public SurfaceDescriptorFromWaylandSurfaceFFI()
	{
		this.Chain = default;
		this.Display = default;
		this.Surface = default;
	}

	public SurfaceDescriptorFromWaylandSurfaceFFI(ChainedStruct chain = default, void* display = default, void* surface = default)
	{
		this.Chain = chain;
		this.Display = display;
		this.Surface = surface;
	}
}

