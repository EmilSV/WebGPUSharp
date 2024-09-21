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

}
