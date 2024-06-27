using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryAHardwareBufferDescriptorFFI
{
    public ChainedStruct Chain;
    public void* Handle;
    public WebGPUBool UseExternalFormat;

    public SharedTextureMemoryAHardwareBufferDescriptorFFI()
    {
    }


    public SharedTextureMemoryAHardwareBufferDescriptorFFI(ChainedStruct chain = default, void* handle = default, WebGPUBool useExternalFormat = default)
    {
        this.Chain = chain;
        this.Handle = handle;
        this.UseExternalFormat = useExternalFormat;
    }

}
