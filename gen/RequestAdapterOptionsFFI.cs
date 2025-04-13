using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Additional information required when requesting an adapter.
/// 
/// For use with <see cref="InstanceHandle.RequestAdapter"></see>.
/// </summary>
public unsafe partial struct RequestAdapterOptionsFFI
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
    /// Surface that is required to be presentable with the requested adapter. This does not create the surface, only guarantees that the adapter can present to said surface.
    /// </summary>
    public SurfaceHandle CompatibleSurface;
    public FeatureLevel FeatureLevel;
    /// <summary>
    /// Power preference for the adapter.
    /// </summary>
    public PowerPreference PowerPreference;
    /// <summary>
    /// The backend type of the resulting adapter.
    /// </summary>
    public BackendType BackendType;
    /// <summary>
    /// Indicates that only a fallback adapter can be returned. This is generally a “software” implementation on the system.
    /// </summary>
    public WebGPUBool ForceFallbackAdapter = false;

    public RequestAdapterOptionsFFI() { }

}
