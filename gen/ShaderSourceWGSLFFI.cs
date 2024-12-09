using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderSourceWGSLFFI
{
    public ChainedStruct Chain;
    public StringViewFFI Code = StringViewFFI.NullValue;

    public ShaderSourceWGSLFFI() { }

}
