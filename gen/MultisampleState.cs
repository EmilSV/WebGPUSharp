using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct MultisampleState
{
    public ChainedStruct* NextInChain;
    public uint Count;
    public uint Mask;
    public WebGPUBool AlphaToCoverageEnabled;

    public MultisampleState()
    {
    }


    public MultisampleState(ChainedStruct* nextInChain = default, uint count = 1, uint mask = 4294967295, WebGPUBool alphaToCoverageEnabled = false)
    {
        this.NextInChain = nextInChain;
        this.Count = count;
        this.Mask = mask;
        this.AlphaToCoverageEnabled = alphaToCoverageEnabled;
    }


    public MultisampleState(uint count = 1, uint mask = 4294967295, WebGPUBool alphaToCoverageEnabled = false)
    {
        this.Count = count;
        this.Mask = mask;
        this.AlphaToCoverageEnabled = alphaToCoverageEnabled;
    }

}
