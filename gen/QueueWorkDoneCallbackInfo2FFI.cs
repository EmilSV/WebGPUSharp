using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QueueWorkDoneCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public QueueWorkDoneCallbackInfo2FFI() { }

}
