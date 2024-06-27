using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDXGISharedHandleExportInfoFFI
{
    public ChainedStructOut Chain;
    public void* Handle;

    public SharedFenceDXGISharedHandleExportInfoFFI()
    {
    }


    public SharedFenceDXGISharedHandleExportInfoFFI(ChainedStructOut chain = default, void* handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
