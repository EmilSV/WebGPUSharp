using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CreateRenderPipelineAsyncCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, byte*, void*, void> Callback;
    public void* Userdata;

    public CreateRenderPipelineAsyncCallbackInfoFFI()
    {
    }


    public CreateRenderPipelineAsyncCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public CreateRenderPipelineAsyncCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
