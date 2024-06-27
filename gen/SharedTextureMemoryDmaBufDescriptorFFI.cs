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

    public SharedTextureMemoryDmaBufDescriptorFFI()
    {
    }


    public SharedTextureMemoryDmaBufDescriptorFFI(ChainedStruct chain = default, Extent3D size = default, uint drmFormat = default, ulong drmModifier = default, nuint planeCount = default, SharedTextureMemoryDmaBufPlane* planes = default)
    {
        this.Chain = chain;
        this.Size = size;
        this.DrmFormat = drmFormat;
        this.DrmModifier = drmModifier;
        this.PlaneCount = planeCount;
        this.Planes = planes;
    }

}
