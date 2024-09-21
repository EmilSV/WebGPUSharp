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

}
