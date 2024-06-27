using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnWireWGSLControl
{
    public ChainedStruct Chain;
    public WebGPUBool EnableExperimental;
    public WebGPUBool EnableUnsafe;
    public WebGPUBool EnableTesting;

    public DawnWireWGSLControl()
    {
    }


    public DawnWireWGSLControl(ChainedStruct chain = default, WebGPUBool enableExperimental = default, WebGPUBool enableUnsafe = default, WebGPUBool enableTesting = default)
    {
        this.Chain = chain;
        this.EnableExperimental = enableExperimental;
        this.EnableUnsafe = enableUnsafe;
        this.EnableTesting = enableTesting;
    }

}
