using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceMTLSharedEventExportInfoFFI
{
    public ChainedStructOut Chain;
    public void* SharedEvent;

    public SharedFenceMTLSharedEventExportInfoFFI() { }

}
