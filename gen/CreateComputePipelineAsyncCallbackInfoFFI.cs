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

}
