using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnEncoderInternalUsageDescriptor
{
    public ChainedStruct Chain = new();
    public WebGPUBool UseInternalUsages = new();

    public DawnEncoderInternalUsageDescriptor() { }

}
