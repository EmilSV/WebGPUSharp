using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDXGISharedHandleDescriptorFFI
{
    public ChainedStruct Chain;
    public void* Handle;

    public SharedFenceDXGISharedHandleDescriptorFFI() { }

}
