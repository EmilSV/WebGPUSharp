using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct AHardwareBufferProperties
{
    public YCbCrVkDescriptor YCbCrInfo;

    public AHardwareBufferProperties()
    {
    }


    public AHardwareBufferProperties(YCbCrVkDescriptor yCbCrInfo = default)
    {
        this.YCbCrInfo = yCbCrInfo;
    }

}
