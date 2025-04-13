using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// The <see cref="SurfaceCapabilitiesFFI" />
/// struct is used to pass a list of supported capabilities to the WebGPU API.
/// </summary>
public unsafe partial struct SurfaceCapabilitiesFFI
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
    /// Bitflag of supported texture usages for the surface to use with the given adapter.
    /// 
    /// The usage <see cref="WebGpuSharp.TextureUsages.RenderAttachment" /> is guaranteed.
    /// </summary>
    public TextureUsage Usages;
    /// <summary>
    /// The number of items in the <see cref="Formats" /> sequence.
    /// </summary>
    public nuint FormatCount;
    /// <summary>
    /// List of supported formats to use with the given adapter. The first format in the sequence is preferred.
    /// 
    /// Returns an empty vector if the surface is incompatible with the adapter.
    /// </summary>
    public TextureFormat* Formats;
    /// <summary>
    /// The number of items in the <see cref="PresentModes" />
    /// sequence.
    /// </summary>
    public nuint PresentModeCount;
    /// <summary>
    /// List of supported presentation modes to use with the given adapter.
    /// 
    /// Returns an empty vector if the surface is incompatible with the adapter.
    /// </summary>
    public PresentMode* PresentModes;
    /// <summary>
    /// The number of items in the <see cref="AlphaModes" />
    /// sequence.
    /// </summary>
    public nuint AlphaModeCount;
    /// <summary>
    /// List of supported alpha modes to use with the given adapter.
    /// 
    /// Will return at least one element, <see cref="CompositeAlphaMode.Opaque" /> or <see cref="CompositeAlphaMode.Inherit" />.
    /// </summary>
    public CompositeAlphaMode* AlphaModes;

    public SurfaceCapabilitiesFFI() { }

}
