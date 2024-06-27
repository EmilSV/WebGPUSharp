using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryDmaBufPlane
{
    public int Fd;
    public ulong Offset;
    public uint Stride;

    public SharedTextureMemoryDmaBufPlane()
    {
    }


    public SharedTextureMemoryDmaBufPlane(int fd = default, ulong offset = default, uint stride = default)
    {
        this.Fd = fd;
        this.Offset = offset;
        this.Stride = stride;
    }

}
