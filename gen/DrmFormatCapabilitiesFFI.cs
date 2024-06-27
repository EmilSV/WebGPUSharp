using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DrmFormatCapabilitiesFFI
{
    public ChainedStructOut Chain;
    public nuint PropertiesCount;
    public DrmFormatProperties* Properties;

    public DrmFormatCapabilitiesFFI()
    {
    }


    public DrmFormatCapabilitiesFFI(ChainedStructOut chain = default, nuint propertiesCount = default, DrmFormatProperties* properties = default)
    {
        this.Chain = chain;
        this.PropertiesCount = propertiesCount;
        this.Properties = properties;
    }

}
