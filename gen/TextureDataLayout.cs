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


    public TextureDataLayout(ChainedStruct* nextInChain = default, ulong offset = default, uint bytesPerRow = default, uint rowsPerImage = default)
    {
        this.NextInChain = nextInChain;
        this.Offset = offset;
        this.BytesPerRow = bytesPerRow;
        this.RowsPerImage = rowsPerImage;
    }


    public TextureDataLayout(ulong offset = default, uint bytesPerRow = default, uint rowsPerImage = default)
    {
        this.Offset = offset;
        this.BytesPerRow = bytesPerRow;
        this.RowsPerImage = rowsPerImage;
    }

}
