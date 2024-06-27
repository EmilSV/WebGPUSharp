using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceMTLSharedEventExportInfoFFI
{
    public ChainedStructOut Chain;
    public void* SharedEvent;

    public SharedFenceMTLSharedEventExportInfoFFI()
    {
    }


    public SharedFenceMTLSharedEventExportInfoFFI(ChainedStructOut chain = default, void* sharedEvent = default)
    {
        this.Chain = chain;
        this.SharedEvent = sharedEvent;
    }

}
