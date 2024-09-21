using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct FragmentStateFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public byte* EntryPoint;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;
    public nuint TargetCount;
    public required ColorTargetStateFFI* Targets;

    public FragmentStateFFI()
    {
    }

}
