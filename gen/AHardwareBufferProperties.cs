using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AHardwareBufferProperties
{
    public YCbCrVkDescriptor YCbCrInfo = new();

    public AHardwareBufferProperties() { }

}
