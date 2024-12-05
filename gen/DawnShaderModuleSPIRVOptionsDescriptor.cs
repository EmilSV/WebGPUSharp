using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnShaderModuleSPIRVOptionsDescriptor
{
    public ChainedStruct Chain;
    public WebGPUBool AllowNonUniformDerivatives = new();

    public DawnShaderModuleSPIRVOptionsDescriptor() { }

}
