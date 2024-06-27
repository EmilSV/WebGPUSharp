using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct ShaderModuleCompilationOptions
{
    public ChainedStruct Chain;
    public WebGPUBool StrictMath;

    public ShaderModuleCompilationOptions()
    {
    }


    public ShaderModuleCompilationOptions(ChainedStruct chain = default, WebGPUBool strictMath = default)
    {
        this.Chain = chain;
        this.StrictMath = strictMath;
    }

}
