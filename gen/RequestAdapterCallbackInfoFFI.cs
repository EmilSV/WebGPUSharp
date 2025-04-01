using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a callback that is invoked when a request to get an adapter is completed.
/// </summary>
public unsafe partial struct RequestAdapterCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The callback mode.
    /// </summary>
    public CallbackMode Mode;
    /// <summary>
    /// The callback to invoke when the request is completed.
    /// </summary>
    public delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, StringViewFFI, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public RequestAdapterCallbackInfoFFI() { }

}
