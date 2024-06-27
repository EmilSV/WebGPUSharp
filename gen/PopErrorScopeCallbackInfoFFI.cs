using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PopErrorScopeCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<PopErrorScopeStatus, ErrorType, byte*, void*, void> Callback;
    public delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> OldCallback;
    public void* Userdata;

    public PopErrorScopeCallbackInfoFFI()
    {
    }


    public PopErrorScopeCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<PopErrorScopeStatus, ErrorType, byte*, void*, void> callback = default, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> oldCallback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.OldCallback = oldCallback;
        this.Userdata = userdata;
    }


    public PopErrorScopeCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<PopErrorScopeStatus, ErrorType, byte*, void*, void> callback = default, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> oldCallback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.OldCallback = oldCallback;
        this.Userdata = userdata;
    }

}
