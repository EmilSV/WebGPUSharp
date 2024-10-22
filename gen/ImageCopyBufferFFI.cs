using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyBufferFFI
{
    public TextureDataLayout Layout;
    /// <summary>
    /// A buffer which either contains image data to be copied or will store the image data being
    /// copied, depending on the method it is being passed to.
    /// </summary>
    public required BufferHandle Buffer;

    public ImageCopyBufferFFI() { }

}
