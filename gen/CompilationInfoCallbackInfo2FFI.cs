using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CompilationInfoCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public CompilationInfoCallbackInfo2FFI()
    {
    }


    public CompilationInfoCallbackInfo2FFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }


    public CompilationInfoCallbackInfo2FFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }

}