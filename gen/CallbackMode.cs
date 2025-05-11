using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The callback mode to use when calling a asynchronous function.
/// </summary>
public enum CallbackMode
{
    /// <summary>
    /// fire when the asynchronous operation's future is passed to a call to
    /// <see cref="FFI.InstanceHandle.WaitAny" /> AND the operation has already completed or it completes inside the call to <see cref="FFI.InstanceHandle.WaitAny" />.
    /// </summary>
    WaitAnyOnly = 1,
    /// <summary>
    /// fire for the same reasons as callbacks created with <see cref="WaitAnyOnly" />.
    /// fire inside a call to <see cref="FFI.InstanceHandle.ProcessEvents" /> if the asynchronous operation is complete.
    /// </summary>
    AllowProcessEvents = 2,
    /// <summary>
    /// fire for the same reasons as callbacks created with <see cref="AllowProcessEvents" />
    /// may fire spontaneously on an arbitrary or application thread, when the WebGPU implementations discovers that the asynchronous operation is complete.
    /// Implementations should fire spontaneous callbacks as soon as possible.
    /// </summary>
    /// <remarks>
    /// Because spontaneous callbacks may fire at an arbitrary time on an arbitrary thread,
    /// applications should take extra care when acquiring locks or mutating state inside the callback.
    /// It undefined behavior to re-entrantly call into the webgpu API if the callback fires while inside the callstack of another webgpu function that is not
    /// <see cref="FFI.InstanceHandle.WaitAny" /> or <see cref="FFI.InstanceHandle.ProcessEvents" />.
    /// </remarks>
    AllowSpontaneous = 3,
}
