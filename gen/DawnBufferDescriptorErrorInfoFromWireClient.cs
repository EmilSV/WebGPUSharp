using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnBufferDescriptorErrorInfoFromWireClient
{
    public ChainedStruct Chain;
    public WebGPUBool OutOfMemory;

    public DawnBufferDescriptorErrorInfoFromWireClient()
    {
    }


    public DawnBufferDescriptorErrorInfoFromWireClient(ChainedStruct chain = default, WebGPUBool outOfMemory = default)
    {
        this.Chain = chain;
        this.OutOfMemory = outOfMemory;
    }

}
