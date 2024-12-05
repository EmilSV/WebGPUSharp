using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AdapterPropertiesSubgroups
{
    public ChainedStructOut Chain = new();
    public uint MinSubgroupSize;
    public uint MaxSubgroupSize;

    public AdapterPropertiesSubgroups() { }

}
