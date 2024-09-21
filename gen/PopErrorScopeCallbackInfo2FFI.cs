using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PopErrorScopeCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<PopErrorScopeStatus, ErrorType, byte*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public PopErrorScopeCallbackInfo2FFI()
    {
    }

}
