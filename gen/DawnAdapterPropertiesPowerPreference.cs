using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnAdapterPropertiesPowerPreference
{
    public ChainedStructOut Chain = new();
    public PowerPreference PowerPreference;

    public DawnAdapterPropertiesPowerPreference() { }

}
