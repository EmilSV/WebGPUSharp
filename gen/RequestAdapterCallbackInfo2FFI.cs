using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RequestAdapterCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, StringViewFFI, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public RequestAdapterCallbackInfo2FFI() { }

}
