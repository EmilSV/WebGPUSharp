using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureViewDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
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

    public TextureViewDescriptorFFI() { }

}
