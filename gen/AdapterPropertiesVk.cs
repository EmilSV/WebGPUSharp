using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AdapterPropertiesVk
{
    public ChainedStructOut Chain;
    public uint DriverVersion;

    public AdapterPropertiesVk()
    {
    }


    public AdapterPropertiesVk(ChainedStructOut chain = default, uint driverVersion = default)
    {
        this.Chain = chain;
        this.DriverVersion = driverVersion;
    }

}
