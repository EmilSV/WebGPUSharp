using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryDXGISharedHandleDescriptorFFI
{
    public ChainedStruct Chain;
    public void* Handle;
    public WebGPUBool UseKeyedMutex;

    public SharedTextureMemoryDXGISharedHandleDescriptorFFI() { }

}
