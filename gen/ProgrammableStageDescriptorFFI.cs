using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ProgrammableStageDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public StringViewFFI EntryPoint;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;

    public ProgrammableStageDescriptorFFI()
    {
    }

}
