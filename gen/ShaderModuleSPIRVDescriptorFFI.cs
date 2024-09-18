using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleSPIRVDescriptorFFI
{
    public ShaderSourceSPIRVFFI Value;

    public ShaderModuleSPIRVDescriptorFFI()
    {
    }


    public ShaderModuleSPIRVDescriptorFFI(ShaderSourceSPIRVFFI value = default)
    {
        this.Value = value;
    }

}
