using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnShaderModuleSPIRVOptionsDescriptor
{
    public ChainedStruct Chain;
    public WebGPUBool AllowNonUniformDerivatives;

    public DawnShaderModuleSPIRVOptionsDescriptor()
    {
    }


    public DawnShaderModuleSPIRVOptionsDescriptor(ChainedStruct chain = default, WebGPUBool allowNonUniformDerivatives = default)
    {
        this.Chain = chain;
        this.AllowNonUniformDerivatives = allowNonUniformDerivatives;
    }

}
