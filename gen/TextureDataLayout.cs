using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Layout of a texture in a buffer's memory.
/// </summary>
public unsafe partial struct TextureDataLayout
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
    /// Offset into the buffer that is the start of the texture. Must be a multiple of texture block size.
    /// </summary>
    public ulong Offset;
    /// <summary>
    /// Bytes per "row" of the image. This represents one row of pixels in the x direction.
    /// 
    /// Compressed textures include multiple rows of pixels in each "row". May be 0 for 1D texture copies.
    /// 
    /// Must be a multiple of the texture block size.
    /// </summary>
    public uint BytesPerRow;
    /// <summary>
    /// Rows that make up a single "image". Each "image" is one layer in the z direction of a 3D image.
    /// </summary>
    public uint RowsPerImage;

    public TextureDataLayout() { }

}
