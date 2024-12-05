using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryIOSurfaceDescriptorFFI
{
    public ChainedStruct Chain;
    public void* IoSurface;

    public SharedTextureMemoryIOSurfaceDescriptorFFI() { }

}
