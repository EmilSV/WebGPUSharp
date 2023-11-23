using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BufferMapCallbackInfoFFI
{
	public ChainedStruct* NextInChain;
	public CallbackMode Mode;
	public delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> Callback;
	public void* Userdata;

	public BufferMapCallbackInfoFFI()
	{
		this.NextInChain = default;
		this.Mode = default;
		this.Callback = default;
		this.Userdata = default;
	}

	public BufferMapCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> callback = default, void* userdata = default)
	{
		this.Mode = mode;
		this.Callback = callback;
		this.Userdata = userdata;
	}

	public BufferMapCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> callback = default, void* userdata = default)
	{
		this.NextInChain = nextInChain;
		this.Mode = mode;
		this.Callback = callback;
		this.Userdata = userdata;
	}
}

