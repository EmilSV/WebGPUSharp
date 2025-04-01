using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// A storage texture binding layout.
/// </summary>
public unsafe partial struct StorageTextureBindingLayout
{
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
