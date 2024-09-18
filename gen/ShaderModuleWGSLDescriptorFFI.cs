using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleWGSLDescriptorFFI
{
    public ShaderSourceWGSLFFI Value;

    public ShaderModuleWGSLDescriptorFFI()
    {
    }


    public ShaderModuleWGSLDescriptorFFI(ShaderSourceWGSLFFI value = default)
    {
        this.Value = value;
    }

}
