using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDXGISharedHandleExportInfoFFI
{
    public ChainedStructOut Chain;
    public void* Handle;

    public SharedFenceDXGISharedHandleExportInfoFFI() { }

}
