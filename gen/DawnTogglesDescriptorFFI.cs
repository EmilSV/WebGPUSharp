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

    public DawnTogglesDescriptorFFI()
    {
    }


    public DawnTogglesDescriptorFFI(ChainedStruct chain = default, nuint enabledToggleCount = default, byte** enabledToggles = default, nuint disabledToggleCount = default, byte** disabledToggles = default)
    {
        this.Chain = chain;
        this.EnabledToggleCount = enabledToggleCount;
        this.EnabledToggles = enabledToggles;
        this.DisabledToggleCount = disabledToggleCount;
        this.DisabledToggles = disabledToggles;
    }

}
