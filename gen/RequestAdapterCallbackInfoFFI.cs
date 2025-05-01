using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a callback that is invoked when a request to get an adapter is completed.
/// </summary>
public unsafe partial struct RequestAdapterCallbackInfoFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The callback mode.
    /// </summary>
    public CallbackMode Mode;
    /// <summary>
    /// The callback to invoke when the request is completed.
    /// </summary>
    public delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, StringViewFFI, void*, void*, void> Callback;
    /// <summary>
    /// The first userdata to be passed to the callback.
    /// </summary>
    public void* Userdata1;
    /// <summary>
    /// The second userdata to be passed to the callback.
    /// </summary>
    public void* Userdata2;

    public RequestAdapterCallbackInfoFFI() { }

}
