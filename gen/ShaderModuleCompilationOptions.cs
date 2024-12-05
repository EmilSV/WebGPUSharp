using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct ShaderModuleCompilationOptions
{
    public ChainedStruct Chain = new();
    public WebGPUBool StrictMath = new();

    public ShaderModuleCompilationOptions() { }

}
