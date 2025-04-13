using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureViewDescriptorFFI
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
    /// The debug label of the texture view.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The format of the texture view. Must be either the  <see cref="TextureDescriptor.Format"/> of the
    /// texture or one of the  <see cref="TextureDescriptor.ViewFormats"/> specified during its creation.
    /// </summary>
    public TextureFormat Format;
    /// <summary>
    /// The dimension to view the texture as.
    /// </summary>
    public TextureViewDimension Dimension;
    /// <summary>
    /// The first (most detailed) mipmap level accessible to the texture view.
    /// </summary>
    public uint BaseMipLevel = 0;
    /// <summary>
    /// How many mipmap levels, starting with  <see cref="TextureViewDescriptor.BaseMipLevel"/>, are accessible to
    /// the texture view.
    /// </summary>
    public uint MipLevelCount;
    /// <summary>
    /// The index of the first array layer accessible to the texture view.
    /// </summary>
    public uint BaseArrayLayer = 0;
    /// <summary>
    /// How many array layers, starting with  <see cref="TextureViewDescriptor.BaseArrayLayer"/>, are accessible
    /// to the texture view.
    /// </summary>
    public uint ArrayLayerCount;
    /// <summary>
    /// Which  <see cref="TextureAspect">aspect(s)</see> of the texture are accessible to the texture view.
    /// </summary>
    public TextureAspect Aspect = TextureAspect.All;
    /// <summary>
    /// The allowed  <see cref="TextureUsage">usage(s)</see> for the texture view. Must be a subset of the
    ///  <see cref="Texture.Usage"/> flags of the texture. If 0, defaults to the full set of
    ///  <see cref="Texture.Usage"/> flags of the texture.
    /// Note: If the view's  <see cref="TextureViewDescriptor.Format"/> doesn't support all of the
    /// texture's  <see cref="TextureDescriptor.Usage"/>s, the default will fail,
    /// and the view's  <see cref="TextureViewDescriptor.Usage"/> must be specified explicitly.
    /// </summary>
    public TextureUsage Usage = TextureUsage.None;

    public TextureViewDescriptorFFI() { }

}
