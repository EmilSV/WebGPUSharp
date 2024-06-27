using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromWindowsSwapChainPanelFFI
{
    public ChainedStruct Chain;
    public void* SwapChainPanel;

    public SurfaceDescriptorFromWindowsSwapChainPanelFFI()
    {
    }


    public SurfaceDescriptorFromWindowsSwapChainPanelFFI(ChainedStruct chain = default, void* swapChainPanel = default)
    {
        this.Chain = chain;
        this.SwapChainPanel = swapChainPanel;
    }

}
