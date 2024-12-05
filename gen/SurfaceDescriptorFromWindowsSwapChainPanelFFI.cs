using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromWindowsSwapChainPanelFFI
{
    public ChainedStruct Chain = new();
    public void* SwapChainPanel;

    public SurfaceDescriptorFromWindowsSwapChainPanelFFI() { }

}
