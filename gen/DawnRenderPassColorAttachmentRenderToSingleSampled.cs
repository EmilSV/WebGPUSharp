using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnRenderPassColorAttachmentRenderToSingleSampled
{
    public ChainedStruct Chain;
    public uint ImplicitSampleCount;

    public DawnRenderPassColorAttachmentRenderToSingleSampled()
    {
    }


    public DawnRenderPassColorAttachmentRenderToSingleSampled(ChainedStruct chain = default, uint implicitSampleCount = default)
    {
        this.Chain = chain;
        this.ImplicitSampleCount = implicitSampleCount;
    }

}
