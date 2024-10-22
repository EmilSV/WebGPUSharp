using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct ShaderModuleCompilationOptions
{
    public ChainedStruct Chain;
    public WebGPUBool StrictMath;

    public ShaderModuleCompilationOptions() { }

}
