using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryAHardwareBufferProperties
{
    public ChainedStructOut Chain;
    public YCbCrVkDescriptor YCbCrInfo;

    public SharedTextureMemoryAHardwareBufferProperties()
    {
    }


    public SharedTextureMemoryAHardwareBufferProperties(ChainedStructOut chain = default, YCbCrVkDescriptor yCbCrInfo = default)
    {
        this.Chain = chain;
        this.YCbCrInfo = yCbCrInfo;
    }

}
