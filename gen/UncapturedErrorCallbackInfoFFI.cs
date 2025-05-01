using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A UncapturedErrorCallbackInfoFFI is a callback info struct used to register a callback for when a uncaptured error happens.
/// </summary>
public unsafe partial struct UncapturedErrorCallbackInfoFFI
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
    /// The callback to call when the uncaptured error happens.
    /// </summary>
    public delegate* unmanaged[Cdecl]<DeviceHandle*, ErrorType, StringViewFFI, void*, void*, void> Callback;
    /// <summary>
    /// User data pointer 1.
    /// </summary>
    public void* Userdata1;
    /// <summary>
    /// User data pointer 2.
    /// </summary>
    public void* Userdata2;

    public UncapturedErrorCallbackInfoFFI() { }

}
