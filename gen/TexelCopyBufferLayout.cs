using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Layout of a texture in a buffer's memory.
/// </summary>
public partial struct TexelCopyBufferLayout
{
    /// <summary>
    /// Offset into the buffer that is the start of the texture. Must be a multiple of texture block size. For non-compressed textures, this is 1.
    /// </summary>
    public ulong Offset;
    /// <summary>
    /// Bytes per “row” in an image.
    /// A row is one row of pixels or of compressed blocks in the x direction.
    /// This value is required if there are multiple rows (i.e. height or depth is more than one pixel or pixel block for compressed textures)
    /// Must be a multiple of 256 for <see cref="CommandEncoder.CopyBufferToTexture" /> and <see cref="CommandEncoder.CopyTextureToBuffer" />.
    /// You must manually pad the image such that this is a multiple of 256. It will not affect the image data.
    /// <see cref="Queue.WriteTexture" /> does not have this requirement.
    /// Must be a multiple of the texture block size. For non-compressed textures, this is 1.
    /// </summary>
    public uint BytesPerRow;
    /// <summary>
    /// “Rows” that make up a single “image”.
    /// A row is one row of pixels or of compressed blocks in the x direction.
    /// An image is one layer in the z direction of a 3D image or 2DArray texture.
    /// The amount of rows per image may be larger than the actual amount of rows of data.
    /// Required if there are multiple images (i.e. the depth is more than one).
    /// </summary>
    public uint RowsPerImage;

    public TexelCopyBufferLayout() { }

}
