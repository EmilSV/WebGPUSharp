using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct QueueWorkDoneCallbackInfoFFI
{
	public ChainedStruct* NextInChain;
	public CallbackMode Mode;
	public delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> Callback;
	public void* Userdata;

	public QueueWorkDoneCallbackInfoFFI()
	{
		this.NextInChain = default;
		this.Mode = default;
		this.Callback = default;
		this.Userdata = default;
	}

	public QueueWorkDoneCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback = default, void* userdata = default)
	{
		this.Mode = mode;
		this.Callback = callback;
		this.Userdata = userdata;
	}

	public QueueWorkDoneCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback = default, void* userdata = default)
	{
		this.NextInChain = nextInChain;
		this.Mode = mode;
		this.Callback = callback;
		this.Userdata = userdata;
	}
}

