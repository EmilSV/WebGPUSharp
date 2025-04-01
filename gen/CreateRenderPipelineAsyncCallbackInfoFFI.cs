using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A CreateRenderPipelineAsyncCallbackInfoFFI is a callback info struct used to register a callback for when a render pipeline is created.
/// </summary>
public unsafe partial struct CreateRenderPipelineAsyncCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The callback mode.
    /// </summary>
    public CallbackMode Mode;
    /// <summary>
    /// The callback to call when the render pipeline is created.
    /// </summary>
    public delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, StringViewFFI, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public CreateRenderPipelineAsyncCallbackInfoFFI() { }

}
