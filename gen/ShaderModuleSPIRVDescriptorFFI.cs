using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleSPIRVDescriptorFFI
{
    public ChainedStruct Chain;
    public uint CodeSize;
    public uint* Code;

    public ShaderModuleSPIRVDescriptorFFI()
    {
    }


    public ShaderModuleSPIRVDescriptorFFI(ChainedStruct chain = default, uint codeSize = default, uint* code = default)
    {
        this.Chain = chain;
        this.CodeSize = codeSize;
        this.Code = code;
    }

}
