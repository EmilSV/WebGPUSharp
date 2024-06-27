using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CreateComputePipelineAsyncCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void> Callback;
    public void* Userdata;

    public CreateComputePipelineAsyncCallbackInfoFFI()
    {
    }


    public CreateComputePipelineAsyncCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public CreateComputePipelineAsyncCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
