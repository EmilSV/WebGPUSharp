using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnAdapterPropertiesPowerPreference
{
    public ChainedStructOut Chain;
    public PowerPreference PowerPreference;

    public DawnAdapterPropertiesPowerPreference()
    {
    }


    public DawnAdapterPropertiesPowerPreference(ChainedStructOut chain = default, PowerPreference powerPreference = default)
    {
        this.Chain = chain;
        this.PowerPreference = powerPreference;
    }

}
