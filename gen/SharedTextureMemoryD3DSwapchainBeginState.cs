using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryD3DSwapchainBeginState
{
    public ChainedStruct Chain;
    public WebGPUBool IsSwapchain;

    public SharedTextureMemoryD3DSwapchainBeginState()
    {
    }


    public SharedTextureMemoryD3DSwapchainBeginState(ChainedStruct chain = default, WebGPUBool isSwapchain = default)
    {
        this.Chain = chain;
        this.IsSwapchain = isSwapchain;
    }

}
