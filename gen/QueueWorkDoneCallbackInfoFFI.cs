using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QueueWorkDoneCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> Callback;
    public void* Userdata;

    public QueueWorkDoneCallbackInfoFFI() { }

}
