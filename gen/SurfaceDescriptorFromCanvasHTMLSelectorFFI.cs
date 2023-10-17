using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromCanvasHTMLSelectorFFI
{
	public ChainedStruct Chain;
	public byte* Selector;

	public SurfaceDescriptorFromCanvasHTMLSelectorFFI()
	{
		this.Chain = default;
		this.Selector = default;
	}

	public SurfaceDescriptorFromCanvasHTMLSelectorFFI(ChainedStruct chain = default, byte* selector = default)
	{
		this.Chain = chain;
		this.Selector = selector;
	}
}

