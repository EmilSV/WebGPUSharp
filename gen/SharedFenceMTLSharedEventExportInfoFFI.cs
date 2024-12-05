using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceMTLSharedEventExportInfoFFI
{
    public ChainedStructOut Chain = new();
    public void* SharedEvent;

    public SharedFenceMTLSharedEventExportInfoFFI() { }

}
