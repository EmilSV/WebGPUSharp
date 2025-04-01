using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a callback to be called when a queue work done event is fired.
/// </summary>
public unsafe partial struct QueueWorkDoneCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The callback mode.
    /// </summary>
    public CallbackMode Mode;
    /// <summary>
    /// The callback to be called when a queue work done event is fired.
    /// </summary>
    public delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public QueueWorkDoneCallbackInfoFFI() { }

}
