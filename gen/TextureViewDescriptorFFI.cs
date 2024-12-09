using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureViewDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The format of the texture view. Must be either the  <see cref="WebGpuSharp.TextureDescriptor.Format"/> of the
    /// texture or one of the  <see cref="WebGpuSharp.TextureDescriptor.ViewFormats"/> specified during its creation.
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
    /// How many mipmap levels, starting with  <see cref="WebGpuSharp.TextureViewDescriptor.BaseMipLevel"/>, are accessible to
    /// the texture view.
    /// </summary>
    public uint MipLevelCount;
    /// <summary>
    /// The index of the first array layer accessible to the texture view.
    /// </summary>
    public uint BaseArrayLayer = 0;
    /// <summary>
    /// How many array layers, starting with  <see cref="WebGpuSharp.TextureViewDescriptor.BaseArrayLayer"/>, are accessible
    /// to the texture view.
    /// </summary>
    public uint ArrayLayerCount;
    /// <summary>
    /// Which  <see cref="TextureAspect">aspect(s)</see> of the texture are accessible to the texture view.
    /// </summary>
    public TextureAspect Aspect = TextureAspect.All;
    /// <summary>
    /// The allowed  <see cref="TextureUsage">usage(s)</see> for the texture view. Must be a subset of the
    ///  <see cref="WebGpuSharp.Texture.Usage"/> flags of the texture. If 0, defaults to the full set of
    ///  <see cref="WebGpuSharp.Texture.Usage"/> flags of the texture.
    /// Note: If the view's  <see cref="WebGpuSharp.TextureViewDescriptor.Format"/> doesn't support all of the
    /// texture's  <see cref="WebGpuSharp.TextureDescriptor.Usage"/>s, the default will fail,
    /// and the view's  <see cref="WebGpuSharp.TextureViewDescriptor.Usage"/> must be specified explicitly.
    /// </summary>
    public TextureUsage Usage = TextureUsage.None;

    public TextureViewDescriptorFFI() { }

}
