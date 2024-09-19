using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint HintCount;
    public ShaderModuleCompilationHintFFI* Hints;

    public ShaderModuleDescriptorFFI()
    {
    }


    public ShaderModuleDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint hintCount = default, ShaderModuleCompilationHintFFI* hints = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.HintCount = hintCount;
        this.Hints = hints;
    }


    public ShaderModuleDescriptorFFI(byte* label = default, nuint hintCount = default, ShaderModuleCompilationHintFFI* hints = default)
    {
        this.Label = label;
        this.HintCount = hintCount;
        this.Hints = hints;
    }

}
