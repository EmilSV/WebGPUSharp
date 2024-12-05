using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PopErrorScopeCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<PopErrorScopeStatus, ErrorType, StringViewFFI, void*, void> Callback;
    public delegate* unmanaged[Cdecl]<ErrorType, StringViewFFI, void*, void> OldCallback;
    public void* Userdata;

    public PopErrorScopeCallbackInfoFFI() { }

}
