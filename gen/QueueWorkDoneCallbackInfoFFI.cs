using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QueueWorkDoneCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> Callback;
    public void* Userdata;

    public QueueWorkDoneCallbackInfoFFI()
    {
    }


    public QueueWorkDoneCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public QueueWorkDoneCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
