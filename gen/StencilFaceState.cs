using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct StencilFaceState
{
	public CompareFunction Compare;
	public StencilOperation FailOp;
	public StencilOperation DepthFailOp;
	public StencilOperation PassOp;

	public StencilFaceState()
	{
		this.Compare = default;
		this.FailOp = default;
		this.DepthFailOp = default;
		this.PassOp = default;
	}

	public StencilFaceState(CompareFunction compare = default, StencilOperation failOp = default, StencilOperation depthFailOp = default, StencilOperation passOp = default)
	{
		this.Compare = compare;
		this.FailOp = failOp;
		this.DepthFailOp = depthFailOp;
		this.PassOp = passOp;
	}
}

