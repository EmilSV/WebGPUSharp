using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the color state of a render pipeline.
/// </summary>
public unsafe partial struct ColorTargetStateFFI
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
    /// The  <see cref="TextureFormat"/> of this color target. The pipeline will only be compatible with
    ///  <see cref="RenderPassEncoder"/>s which use a  <see cref="TextureView"/> of this format in the
    /// corresponding color attachment.
    /// </summary>
    public required TextureFormat Format;
    /// <summary>
    /// The blending behavior for this color target. If left undefined, disables blending for this
    /// color target.
    /// </summary>
    public BlendState* Blend;
    /// <summary>
    /// Bitmask controlling which channels are are written to when drawing to this color target.
    /// </summary>
    public ColorWriteMask WriteMask = ColorWriteMask.All;

    public ColorTargetStateFFI() { }

}
