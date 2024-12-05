using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryIOSurfaceDescriptorFFI
{
    public ChainedStruct Chain = new();
    public void* IoSurface;

    public SharedTextureMemoryIOSurfaceDescriptorFFI() { }

}
