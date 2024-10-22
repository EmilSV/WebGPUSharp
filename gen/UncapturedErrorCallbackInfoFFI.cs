using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct UncapturedErrorCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> Callback;
    public void* Userdata;

    public UncapturedErrorCallbackInfoFFI() { }

}
