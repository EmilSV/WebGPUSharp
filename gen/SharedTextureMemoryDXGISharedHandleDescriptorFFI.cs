using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryDXGISharedHandleDescriptorFFI
{
    public ChainedStruct Chain = new();
    public void* Handle;
    public WebGPUBool UseKeyedMutex = new();

    public SharedTextureMemoryDXGISharedHandleDescriptorFFI() { }

}
