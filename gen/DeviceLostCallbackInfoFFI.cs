using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A DeviceLostCallbackInfoFFI is a callback info struct used to register a callback for when a device is lost.
/// </summary>
public unsafe partial struct DeviceLostCallbackInfoFFI
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
    /// The callback to call when the device is lost.
    /// </summary>
    public delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, StringViewFFI, void*, void*, void> Callback;
    /// <summary>
    /// The first user data to be passed to the callback function.
    /// </summary>
    public void* Userdata1;
    /// <summary>
    /// The second user data to be passed to the callback function.
    /// </summary>
    public void* Userdata2;

    public DeviceLostCallbackInfoFFI() { }

}
