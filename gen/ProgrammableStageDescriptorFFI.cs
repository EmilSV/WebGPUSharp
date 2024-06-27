using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ProgrammableStageDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public byte* EntryPoint;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;

    public ProgrammableStageDescriptorFFI()
    {
    }


    public ProgrammableStageDescriptorFFI(ChainedStruct* nextInChain = default, ShaderModuleHandle module = default, byte* entryPoint = default, nuint constantCount = default, ConstantEntryFFI* constants = default)
    {
        this.NextInChain = nextInChain;
        this.Module = module;
        this.EntryPoint = entryPoint;
        this.ConstantCount = constantCount;
        this.Constants = constants;
    }


    public ProgrammableStageDescriptorFFI(ShaderModuleHandle module = default, byte* entryPoint = default, nuint constantCount = default, ConstantEntryFFI* constants = default)
    {
        this.Module = module;
        this.EntryPoint = entryPoint;
        this.ConstantCount = constantCount;
        this.Constants = constants;
    }

}
