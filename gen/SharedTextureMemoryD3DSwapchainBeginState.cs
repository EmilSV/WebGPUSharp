using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryD3DSwapchainBeginState
{
    public ChainedStruct Chain = new();
    public WebGPUBool IsSwapchain = new();

    public SharedTextureMemoryD3DSwapchainBeginState() { }

}
