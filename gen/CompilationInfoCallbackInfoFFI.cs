using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CompilationInfoCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void> Callback;
    public void* Userdata;

    public CompilationInfoCallbackInfoFFI()
    {
    }


    public CompilationInfoCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public CompilationInfoCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
