using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Features enabled on the WGPUInstance
/// </summary>
public unsafe partial struct InstanceCapabilities
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
    /// Enable use of <see cref="FFI.InstanceHandle.WaitAny" /> with `timeoutNS &gt; 0`.
    /// </summary>
    public WebGPUBool TimedWaitAnyEnable = new();
    /// <summary>
    /// The maximum number @ref WGPUFutureWaitInfo supported in a call to <see cref="FFI.InstanceHandle.WaitAny" /> with `timeoutNS &gt; 0`.
    /// </summary>
    public nuint TimedWaitAnyMaxCount;

    public InstanceCapabilities() { }

}
