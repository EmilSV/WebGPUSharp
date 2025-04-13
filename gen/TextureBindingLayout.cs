using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the layout of a texture binding.
/// </summary>
public unsafe partial struct TextureBindingLayout
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
    /// Indicates the type required for texture views bound to this binding.
    /// </summary>
    public TextureSampleType SampleType = TextureSampleType.Float;
    /// <summary>
    /// Indicates the required  <see cref="TextureViewDescriptor.Dimension"/> for texture views bound to
    /// this binding.
    /// </summary>
    public TextureViewDimension ViewDimension = TextureViewDimension.D2;
    /// <summary>
    /// Indicates whether or not texture views bound to this binding must be multisampled.
    /// </summary>
    public WebGPUBool Multisampled = false;

    public TextureBindingLayout() { }

}
