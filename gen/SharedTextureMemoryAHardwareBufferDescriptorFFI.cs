using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryAHardwareBufferDescriptorFFI
{
	public ChainedStruct Chain;
	public void* Handle;

	public SharedTextureMemoryAHardwareBufferDescriptorFFI()
	{
		this.Chain = default;
		this.Handle = default;
	}

	public SharedTextureMemoryAHardwareBufferDescriptorFFI(ChainedStruct chain = default, void* handle = default)
	{
		this.Chain = chain;
		this.Handle = handle;
	}
}

