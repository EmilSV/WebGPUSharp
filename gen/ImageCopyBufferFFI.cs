using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// In an image copy operation, <see cref="ImageCopyBufferFFI" /> defines a <see cref="BufferHandle" /> and, together
/// with the copySize, how image data is laid out in the buffer's memory
/// </summary>
public unsafe partial struct ImageCopyBufferFFI
{
    public TextureDataLayout Layout = new();
    /// <summary>
    /// A buffer which either contains image data to be copied or will store the image data being
    /// copied, depending on the method it is being passed to.
    /// </summary>
    public required BufferHandle Buffer;

    public ImageCopyBufferFFI() { }

}
