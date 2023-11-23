using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BufferHostMappedPointerFFI
{
	public ChainedStruct Chain;
	public void* Pointer;
	public delegate* unmanaged[Cdecl]<void*, void> DisposeCallback;
	public void* Userdata;

	public BufferHostMappedPointerFFI()
	{
		this.Chain = default;
		this.Pointer = default;
		this.DisposeCallback = default;
		this.Userdata = default;
	}

	public BufferHostMappedPointerFFI(ChainedStruct chain = default, void* pointer = default, delegate* unmanaged[Cdecl]<void*, void> disposeCallback = default, void* userdata = default)
	{
		this.Chain = chain;
		this.Pointer = pointer;
		this.DisposeCallback = disposeCallback;
		this.Userdata = userdata;
	}
}

