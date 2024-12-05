using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceMTLSharedEventDescriptorFFI
{
    public ChainedStruct Chain = new();
    public void* SharedEvent;

    public SharedFenceMTLSharedEventDescriptorFFI() { }

}
