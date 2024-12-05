using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryAHardwareBufferProperties
{
    public ChainedStructOut Chain = new();
    public YCbCrVkDescriptor YCbCrInfo = new();

    public SharedTextureMemoryAHardwareBufferProperties() { }

}
