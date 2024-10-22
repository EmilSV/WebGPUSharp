using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnEncoderInternalUsageDescriptor
{
    public ChainedStruct Chain;
    public WebGPUBool UseInternalUsages;

    public DawnEncoderInternalUsageDescriptor() { }

}
