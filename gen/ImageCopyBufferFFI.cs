using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyBufferFFI
{
    public TextureDataLayout Layout;
    public required BufferHandle Buffer;

    public ImageCopyBufferFFI()
    {
    }

}
