using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SurfaceDescriptorFromMetalLayerFFI
{
	public ChainedStruct Chain;
	public void* Layer;

	public SurfaceDescriptorFromMetalLayerFFI()
	{
		this.Chain = default;
		this.Layer = default;
	}

	public SurfaceDescriptorFromMetalLayerFFI(ChainedStruct chain = default, void* layer = default)
	{
		this.Chain = chain;
		this.Layer = layer;
	}
}

