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

    public PopErrorScopeCallbackInfoFFI() { }

}
