using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct StorageTextureBindingLayout
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The access mode for this binding, indicating readability and writability.
    /// </summary>
    public StorageTextureAccess Access = StorageTextureAccess.WriteOnly;
    /// <summary>
    /// The required  <see cref="WebGpuSharp.TextureViewDescriptor.Format"/> of texture views bound to this binding.
    /// </summary>
    public required TextureFormat Format;
    /// <summary>
    /// Indicates the required  <see cref="WebGpuSharp.TextureViewDescriptor.Dimension"/> for texture views bound to
    /// this binding.
    /// </summary>
    public TextureViewDimension ViewDimension = TextureViewDimension.D2;

    public StorageTextureBindingLayout()
    {
    }

}
