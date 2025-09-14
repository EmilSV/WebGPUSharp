using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a callback to be called when a queue work done event is fired.
/// </summary>
public unsafe partial struct QueueWorkDoneCallbackInfoFFI
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
    /// The callback to be called when a queue work done event is fired.
    /// </summary>
    public delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, StringViewFFI, void*, void*, void> Callback;
    /// <summary>
    /// The first userdata to be passed to the callback.
    /// </summary>
    public void* Userdata1;
    /// <summary>
    /// The second userdata to be passed to the callback.
    /// </summary>
    public void* Userdata2;

    public QueueWorkDoneCallbackInfoFFI() { }

}
