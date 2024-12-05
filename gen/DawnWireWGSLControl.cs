using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnWireWGSLControl
{
    public ChainedStruct Chain;
    public WebGPUBool EnableExperimental = new();
    public WebGPUBool EnableUnsafe = new();
    public WebGPUBool EnableTesting = new();

    public DawnWireWGSLControl() { }

}
