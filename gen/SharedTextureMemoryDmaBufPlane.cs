using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryDmaBufPlane
{
    public int Fd;
    public ulong Offset;
    public uint Stride;

    public SharedTextureMemoryDmaBufPlane() { }

}
