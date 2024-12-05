using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryAHardwareBufferDescriptorFFI
{
    public ChainedStruct Chain = new();
    public void* Handle;
    public WebGPUBool UseExternalFormat = new();

    public SharedTextureMemoryAHardwareBufferDescriptorFFI() { }

}
