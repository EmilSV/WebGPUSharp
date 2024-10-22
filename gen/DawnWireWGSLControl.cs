using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnWireWGSLControl
{
    public ChainedStruct Chain;
    public WebGPUBool EnableExperimental;
    public WebGPUBool EnableUnsafe;
    public WebGPUBool EnableTesting;

    public DawnWireWGSLControl() { }

}
