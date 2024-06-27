using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleWGSLDescriptorFFI
{
    public ChainedStruct Chain;
    public byte* Code;

    public ShaderModuleWGSLDescriptorFFI()
    {
    }


    public ShaderModuleWGSLDescriptorFFI(ChainedStruct chain = default, byte* code = default)
    {
        this.Chain = chain;
        this.Code = code;
    }

}
