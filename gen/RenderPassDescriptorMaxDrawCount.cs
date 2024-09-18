using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct RenderPassDescriptorMaxDrawCount
{
    public RenderPassMaxDrawCount Value;

    public RenderPassDescriptorMaxDrawCount()
    {
    }


    public RenderPassDescriptorMaxDrawCount(RenderPassMaxDrawCount value = default)
    {
        this.Value = value;
    }

}
