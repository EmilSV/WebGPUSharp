using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ImageCopyBufferFFI
{
    public TextureDataLayout Layout;
    public BufferHandle Buffer;

    public ImageCopyBufferFFI()
    {
    }


    public ImageCopyBufferFFI(TextureDataLayout layout = default, BufferHandle buffer = default)
    {
        this.Layout = layout;
        this.Buffer = buffer;
    }

}
