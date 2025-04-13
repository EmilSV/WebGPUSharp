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
    public DeviceHandle Device;
    public TextureFormat Format;
    public TextureUsage Usage;
    public nuint ViewFormatCount;
    public TextureFormat* ViewFormats;
    public CompositeAlphaMode AlphaMode;
    public uint Width;
    public uint Height;
    public PresentMode PresentMode;

    public SurfaceConfigurationFFI() { }

}
