using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryIOSurfaceDescriptorFFI
{
	public ChainedStruct Chain;
	public void* IoSurface;

	public SharedTextureMemoryIOSurfaceDescriptorFFI()
	{
		this.Chain = default;
		this.IoSurface = default;
	}

	public SharedTextureMemoryIOSurfaceDescriptorFFI(ChainedStruct chain = default, void* ioSurface = default)
	{
		this.Chain = chain;
		this.IoSurface = ioSurface;
	}
}

