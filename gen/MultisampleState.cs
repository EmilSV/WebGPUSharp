using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct MultisampleState
{
    public ChainedStruct* NextInChain;
    public uint Count = 1;
    public uint Mask = 0xFFFFFFFF;
    public WebGPUBool AlphaToCoverageEnabled = false;

    public MultisampleState()
    {
    }

}
