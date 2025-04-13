using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Texture.
/// 
/// For use with <see cref="DeviceHandle.CreateTexture" />.
/// </summary>
public unsafe partial struct TextureDescriptorFFI
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
    /// A debug label for the texture.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
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
    /// The sample count of the texture. A  <see cref="TextureDescriptor.SampleCount"/> &gt; `1` indicates
    /// a multisampled texture.
    /// </summary>
    public uint SampleCount = 1;
    /// <summary>
    /// The number of entries in the <see cref="ViewFormats" /> sequence.
    /// </summary>
    public nuint ViewFormatCount;
    /// <summary>
    /// Specifies what view  <see cref="TextureViewDescriptor.Format"/> values will be allowed when calling
    ///  <see cref="Texture.CreateView"/> on this texture (in addition to the texture's actual
    ///  <see cref="TextureDescriptor.Format"/>).
    /// 
    /// Formats in this list must be texture view format compatible with the texture format.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Adding a format to this list may have a significant performance impact, so it is best
    /// to avoid adding formats unnecessarily.
    /// The actual performance impact is highly dependent on the target system; developers must
    /// test various systems to find out the impact on their particular application.
    /// For example, on some systems any texture with a  <see cref="TextureDescriptor.Format"/> or
    ///  <see cref="TextureDescriptor.ViewFormats"/> entry including
    ///  <see cref="TextureFormat.Rgba8unorm-srgb"/> will perform less optimally than a
    ///  <see cref="TextureFormat.Rgba8unorm"/> texture which does not.
    /// Similar caveats exist for other formats and pairs of formats on other systems.
    /// 
    /// </remarks>
    public TextureFormat* ViewFormats;

    public TextureDescriptorFFI() { }

}
