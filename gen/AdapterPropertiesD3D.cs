using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AdapterPropertiesD3D
{
    public ChainedStructOut Chain = new();
    public uint ShaderModel;

    public AdapterPropertiesD3D() { }

}
