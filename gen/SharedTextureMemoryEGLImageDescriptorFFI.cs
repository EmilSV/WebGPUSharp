using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryEGLImageDescriptorFFI
{
	public ChainedStruct Chain;
	public void* Image;

	public SharedTextureMemoryEGLImageDescriptorFFI()
	{
		this.Chain = default;
		this.Image = default;
	}

	public SharedTextureMemoryEGLImageDescriptorFFI(ChainedStruct chain = default, void* image = default)
	{
		this.Chain = chain;
		this.Image = image;
	}
}

