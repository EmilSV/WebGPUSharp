using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Surface.
/// 
/// For use with <see cref="Surface.Configure" />.
/// </summary>
public unsafe partial struct SurfaceConfigurationFFI
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
    /// The device to use for the swap chain. Must be the same device as the surface.
    /// </summary>
    public DeviceHandle Device;
    /// <summary>
    /// The texture format of the swap chain.
    /// The only formats that are guaranteed are Bgra8Unorm and Bgra8UnormSrgb
    /// </summary>
    public TextureFormat Format;
    /// <summary>
    /// The usage of the swap chain.
    /// </summary>
    public TextureUsage Usage = TextureUsage.RenderAttachment;
    /// <summary>
    /// Width of the swap chain. Must be the same size as the surface, and nonzero.
    /// 
    /// If this is not the same size as the underlying surface (e.g. if it is set once, and the window is later resized),
    /// the behaviour is defined but platform-specific,
    /// and may change in the future (currently macOS scales the surface, other platforms may do something else).
    /// </summary>
    public uint Width;
    /// <summary>
    /// Height of the swap chain. Must be the same size as the surface, and nonzero.
    /// 
    /// If this is not the same size as the underlying surface (e.g. if it is set once, and the window is later resized),
    /// the behaviour is defined but platform-specific, and may change in the future (currently macOS scales the surface,
    /// other platforms may do something else).
    /// </summary>
    public uint Height;
    /// <summary>
    /// The number of view formats in the <see cref="ViewFormats" /> sequence.
    /// </summary>
    public nuint ViewFormatCount = 0;
    /// <summary>
    /// Specifies what view formats will be allowed when calling <see cref="TextureHandle.CreateView" /> on the texture returned by <see cref="SurfaceHandle.GetCurrentTexture" />.
    /// View formats of the same format as the texture are always allowed.
    /// </summary>
    public TextureFormat* ViewFormats = null;
    /// <summary>
    /// Specifies how the alpha channel of the textures should be handled during compositing.
    /// </summary>
    public CompositeAlphaMode AlphaMode = CompositeAlphaMode.Auto;
    /// <summary>
    /// Presentation mode of the swap chain.
    /// Fifo is the only mode guaranteed to be supported. FifoRelaxed, Immediate,
    /// and Mailbox will crash if unsupported.
    /// </summary>
    public PresentMode PresentMode = PresentMode.Fifo;

    public SurfaceConfigurationFFI() { }

}
