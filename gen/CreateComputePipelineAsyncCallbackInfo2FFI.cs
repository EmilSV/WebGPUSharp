using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CreateComputePipelineAsyncCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public CreateComputePipelineAsyncCallbackInfo2FFI()
    {
    }


    public CreateComputePipelineAsyncCallbackInfo2FFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }


    public CreateComputePipelineAsyncCallbackInfo2FFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }

}
