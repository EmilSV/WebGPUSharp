using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// View of a buffer which can be used to copy to/from a texture.
/// </summary>
public unsafe partial struct TexelCopyBufferInfoFFI
{
    /// <summary>
    /// The layout of the texture data in this buffer.
    /// </summary>
    public TexelCopyBufferLayout Layout = new();
    /// <summary>
    /// The buffer to be copied to/from.
    /// </summary>
    public required BufferHandle Buffer;

    public TexelCopyBufferInfoFFI() { }

}
