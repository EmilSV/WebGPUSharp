using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CreateRenderPipelineAsyncCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, byte*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public CreateRenderPipelineAsyncCallbackInfo2FFI()
    {
    }

}
