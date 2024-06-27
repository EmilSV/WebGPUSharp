using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct UncapturedErrorCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> Callback;
    public void* Userdata;

    public UncapturedErrorCallbackInfoFFI()
    {
    }


    public UncapturedErrorCallbackInfoFFI(ChainedStruct* nextInChain = default, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public UncapturedErrorCallbackInfoFFI(delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
