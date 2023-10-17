using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromAndroidNativeWindowFFI
{
	public ChainedStruct Chain;
	public void* Window;

	public SurfaceDescriptorFromAndroidNativeWindowFFI()
	{
		this.Chain = default;
		this.Window = default;
	}

	public SurfaceDescriptorFromAndroidNativeWindowFFI(ChainedStruct chain = default, void* window = default)
	{
		this.Chain = chain;
		this.Window = window;
	}
}

