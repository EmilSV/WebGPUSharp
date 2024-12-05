using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AdapterPropertiesVk
{
    public ChainedStructOut Chain = new();
    public uint DriverVersion;

    public AdapterPropertiesVk() { }

}
