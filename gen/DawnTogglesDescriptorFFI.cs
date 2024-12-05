using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnTogglesDescriptorFFI
{
    public ChainedStruct Chain;
    public nuint EnabledToggleCount;
    public byte** EnabledToggles;
    public nuint DisabledToggleCount;
    public byte** DisabledToggles;

    public DawnTogglesDescriptorFFI() { }

}
