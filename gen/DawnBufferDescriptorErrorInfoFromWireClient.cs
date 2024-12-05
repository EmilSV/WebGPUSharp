using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnBufferDescriptorErrorInfoFromWireClient
{
    public ChainedStruct Chain = new();
    public WebGPUBool OutOfMemory = new();

    public DawnBufferDescriptorErrorInfoFromWireClient() { }

}
