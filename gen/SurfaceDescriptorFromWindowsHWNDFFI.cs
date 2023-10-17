using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromWindowsHWNDFFI
{
	public ChainedStruct Chain;
	public void* Hinstance;
	public void* Hwnd;

	public SurfaceDescriptorFromWindowsHWNDFFI()
	{
		this.Chain = default;
		this.Hinstance = default;
		this.Hwnd = default;
	}

	public SurfaceDescriptorFromWindowsHWNDFFI(ChainedStruct chain = default, void* hinstance = default, void* hwnd = default)
	{
		this.Chain = chain;
		this.Hinstance = hinstance;
		this.Hwnd = hwnd;
	}
}

