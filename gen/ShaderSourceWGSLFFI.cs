using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderSourceWGSLFFI
{
    public ChainedStruct Chain = new();
    public StringViewFFI Code = new();

    public ShaderSourceWGSLFFI() { }

}
