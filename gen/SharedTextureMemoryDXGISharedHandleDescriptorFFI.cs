using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryDXGISharedHandleDescriptorFFI
{
    public ChainedStruct Chain;
    public void* Handle;
    public WebGPUBool UseKeyedMutex;

    public SharedTextureMemoryDXGISharedHandleDescriptorFFI()
    {
    }


    public SharedTextureMemoryDXGISharedHandleDescriptorFFI(ChainedStruct chain = default, void* handle = default, WebGPUBool useKeyedMutex = default)
    {
        this.Chain = chain;
        this.Handle = handle;
        this.UseKeyedMutex = useKeyedMutex;
    }

}
