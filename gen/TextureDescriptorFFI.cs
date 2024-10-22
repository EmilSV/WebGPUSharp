using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct TextureDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    /// <summary>
    /// The allowed usages for the texture.
    /// </summary>
    public required TextureUsage Usage;
    /// <summary>
    /// Whether the texture is one-dimensional, an array of two-dimensional layers, or three-dimensional.
    /// </summary>
    public TextureDimension Dimension = TextureDimension.D2;
    /// <summary>
    /// The width, height, and depth or layer count of the texture.
    /// </summary>
    public required Extent3D Size;
    /// <summary>
    /// The format of the texture.
    /// </summary>
    public required TextureFormat Format;
    /// <summary>
    /// The number of mip levels the texture will contain.
    /// </summary>
    public uint MipLevelCount = 1;
    /// <summary>
    /// The sample count of the texture. A  <see cref="WebGpuSharp.TextureDescriptor.SampleCount"/> &gt; `1` indicates
    /// a multisampled texture.
    /// </summary>
    public uint SampleCount = 1;
    public nuint ViewFormatCount;
    /// <summary>
    /// Specifies what view  <see cref="WebGpuSharp.TextureViewDescriptor.Format"/> values will be allowed when calling
    ///  <see cref="WebGpuSharp.Texture.CreateView"/> on this texture (in addition to the texture's actual
    ///  <see cref="WebGpuSharp.TextureDescriptor.Format"/>).
    /// <remarks>
    /// 
    /// Adding a format to this list may have a significant performance impact, so it is best
    /// to avoid adding formats unnecessarily.
    /// The actual performance impact is highly dependent on the target system; developers must
    /// test various systems to find out the impact on their particular application.
    /// For example, on some systems any texture with a  <see cref="WebGpuSharp.TextureDescriptor.Format"/> or
    ///  <see cref="WebGpuSharp.TextureDescriptor.ViewFormats"/> entry including
    ///  <see cref="TextureFormat.Rgba8unorm-srgb"/> will perform less optimally than a
    ///  <see cref="TextureFormat.Rgba8unorm"/> texture which does not.
    /// Similar caveats exist for other formats and pairs of formats on other systems.
    /// 
    /// </remarks>
    /// Formats in this list must be texture view format compatible with the texture format.
    /// 
    /// </summary>
    public TextureFormat* ViewFormats;

    public TextureDescriptorFFI() { }

}
