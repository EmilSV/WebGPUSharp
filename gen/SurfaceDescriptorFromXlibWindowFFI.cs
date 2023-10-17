using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromXlibWindowFFI
{
	public ChainedStruct Chain;
	public void* Display;
	public uint Window;

	public SurfaceDescriptorFromXlibWindowFFI()
	{
		this.Chain = default;
		this.Display = default;
		this.Window = default;
	}

	public SurfaceDescriptorFromXlibWindowFFI(ChainedStruct chain = default, void* display = default, uint window = default)
	{
		this.Chain = chain;
		this.Display = display;
		this.Window = window;
	}
}

