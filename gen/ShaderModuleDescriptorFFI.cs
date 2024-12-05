using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = new();

    public ShaderModuleDescriptorFFI() { }

}
