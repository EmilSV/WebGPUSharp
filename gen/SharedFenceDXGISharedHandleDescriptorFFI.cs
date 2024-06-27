using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDXGISharedHandleDescriptorFFI
{
    public ChainedStruct Chain;
    public void* Handle;

    public SharedFenceDXGISharedHandleDescriptorFFI()
    {
    }


    public SharedFenceDXGISharedHandleDescriptorFFI(ChainedStruct chain = default, void* handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
