using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface texture.
/// </summary>
public unsafe partial struct SurfaceTextureFFI
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
    /// The texture.
    /// </summary>
    public TextureHandle Texture;
    /// <summary>
    /// The status of the surface texture.
    /// </summary>
    public SurfaceGetCurrentTextureStatus Status;

    public SurfaceTextureFFI() { }

}
