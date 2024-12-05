using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DrmFormatCapabilitiesFFI
{
    public ChainedStructOut Chain = new();
    public nuint PropertiesCount;
    public DrmFormatProperties* Properties;

    public DrmFormatCapabilitiesFFI() { }

}
