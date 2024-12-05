using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleSPIRVDescriptorFFI
{
    public ShaderSourceSPIRVFFI Value = new();

    public ShaderModuleSPIRVDescriptorFFI() { }

}
