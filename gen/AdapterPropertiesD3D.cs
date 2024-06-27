using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AdapterPropertiesD3D
{
    public ChainedStructOut Chain;
    public uint ShaderModel;

    public AdapterPropertiesD3D()
    {
    }


    public AdapterPropertiesD3D(ChainedStructOut chain = default, uint shaderModel = default)
    {
        this.Chain = chain;
        this.ShaderModel = shaderModel;
    }

}
