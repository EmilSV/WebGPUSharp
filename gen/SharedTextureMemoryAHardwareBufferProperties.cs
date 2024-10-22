using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryAHardwareBufferProperties
{
    public ChainedStructOut Chain;
    public YCbCrVkDescriptor YCbCrInfo;

    public SharedTextureMemoryAHardwareBufferProperties() { }

}
