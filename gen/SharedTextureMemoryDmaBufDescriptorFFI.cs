using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryDmaBufDescriptorFFI
{
    public ChainedStruct Chain;
    public Extent3D Size;
    public uint DrmFormat;
    public ulong DrmModifier;
    public nuint PlaneCount;
    public SharedTextureMemoryDmaBufPlane* Planes;

    public SharedTextureMemoryDmaBufDescriptorFFI() { }

}
