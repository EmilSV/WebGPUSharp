using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct TextureDataLayout
{
    public ChainedStruct* NextInChain;
    public ulong Offset;
    public uint BytesPerRow;
    public uint RowsPerImage;

    public TextureDataLayout()
    {
    }

}
