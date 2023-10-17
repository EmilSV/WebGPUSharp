using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromWindowsCoreWindowFFI
{
	public ChainedStruct Chain;
	public void* CoreWindow;

	public SurfaceDescriptorFromWindowsCoreWindowFFI()
	{
		this.Chain = default;
		this.CoreWindow = default;
	}

	public SurfaceDescriptorFromWindowsCoreWindowFFI(ChainedStruct chain = default, void* coreWindow = default)
	{
		this.Chain = chain;
		this.CoreWindow = coreWindow;
	}
}

