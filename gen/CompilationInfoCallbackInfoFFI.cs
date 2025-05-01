using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// CallbackInfo for CompilationInfo.
/// </summary>
public unsafe partial struct CompilationInfoCallbackInfoFFI
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
    /// The mode of the callback.
    /// </summary>
    public CallbackMode Mode;
    /// <summary>
    /// The callback function to be called when the operation is complete.
    /// </summary>
    public delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void*, void> Callback;
    /// <summary>
    /// The first user data to be passed to the callback function.
    /// </summary>
    public void* Userdata1;
    /// <summary>
    /// The second user data to be passed to the callback function.
    /// </summary>
    public void* Userdata2;

    public CompilationInfoCallbackInfoFFI() { }

}
