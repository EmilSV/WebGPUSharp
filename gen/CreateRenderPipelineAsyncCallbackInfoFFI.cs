using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CreateRenderPipelineAsyncCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, StringViewFFI, void*, void> Callback;
    public void* Userdata;

    public CreateRenderPipelineAsyncCallbackInfoFFI() { }

}
