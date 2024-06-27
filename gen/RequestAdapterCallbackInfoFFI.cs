using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RequestAdapterCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, byte*, void*, void> Callback;
    public void* Userdata;

    public RequestAdapterCallbackInfoFFI()
    {
    }


    public RequestAdapterCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public RequestAdapterCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
