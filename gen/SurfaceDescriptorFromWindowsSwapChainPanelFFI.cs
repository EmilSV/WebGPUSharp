using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromWindowsSwapChainPanelFFI
{
	public ChainedStruct Chain;
	public void* SwapChainPanel;

	public SurfaceDescriptorFromWindowsSwapChainPanelFFI()
	{
		this.Chain = default;
		this.SwapChainPanel = default;
	}

	public SurfaceDescriptorFromWindowsSwapChainPanelFFI(ChainedStruct chain = default, void* swapChainPanel = default)
	{
		this.Chain = chain;
		this.SwapChainPanel = swapChainPanel;
	}
}

