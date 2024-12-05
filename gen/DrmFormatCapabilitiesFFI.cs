using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DrmFormatCapabilitiesFFI
{
    public ChainedStructOut Chain;
    public nuint PropertiesCount;
    public DrmFormatProperties* Properties;

    public DrmFormatCapabilitiesFFI() { }

}
