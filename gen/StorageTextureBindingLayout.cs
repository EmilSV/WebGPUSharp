using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// A storage texture binding layout.
/// </summary>
public unsafe partial struct StorageTextureBindingLayout
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
    /// The access mode for this binding, indicating readability and writability.
    /// </summary>
    public StorageTextureAccess Access = StorageTextureAccess.WriteOnly;
    /// <summary>
    /// The required  <see cref="TextureViewDescriptor.Format"/> of texture views bound to this binding.
    /// </summary>
    public required TextureFormat Format;
    /// <summary>
    /// Indicates the required  <see cref="TextureViewDescriptor.Dimension"/> for texture views bound to
    /// this binding.
    /// </summary>
    public TextureViewDimension ViewDimension = TextureViewDimension.D2;

    public StorageTextureBindingLayout() { }

}
