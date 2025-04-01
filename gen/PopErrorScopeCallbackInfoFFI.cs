using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a callback to be called when an error scope is popped.
/// </summary>
public unsafe partial struct PopErrorScopeCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The callback mode.
    /// </summary>
    public CallbackMode Mode;
    /// <summary>
    /// The callback to be called when an error scope is popped. Only one of Callback or OldCallback can be non-null.
    /// </summary>
    public delegate* unmanaged[Cdecl]<PopErrorScopeStatus, ErrorType, StringViewFFI, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public PopErrorScopeCallbackInfoFFI() { }

}
