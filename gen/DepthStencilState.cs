using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct DepthStencilState
{
	public ChainedStruct* NextInChain;
	public TextureFormat Format;
	public WGPUBool DepthWriteEnabled;
	public CompareFunction DepthCompare;
	public StencilFaceState StencilFront;
	public StencilFaceState StencilBack;
	public uint StencilReadMask;
	public uint StencilWriteMask;
	public int DepthBias;
	public float DepthBiasSlopeScale;
	public float DepthBiasClamp;

	public DepthStencilState()
	{
		this.NextInChain = default;
		this.Format = default;
		this.DepthWriteEnabled = default;
		this.DepthCompare = default;
		this.StencilFront = default;
		this.StencilBack = default;
		this.StencilReadMask = default;
		this.StencilWriteMask = default;
		this.DepthBias = default;
		this.DepthBiasSlopeScale = default;
		this.DepthBiasClamp = default;
	}

	public DepthStencilState(TextureFormat format = default, WGPUBool depthWriteEnabled = default, CompareFunction depthCompare = default, StencilFaceState stencilFront = default, StencilFaceState stencilBack = default, uint stencilReadMask = default, uint stencilWriteMask = default, int depthBias = default, float depthBiasSlopeScale = default, float depthBiasClamp = default)
	{
		this.Format = format;
		this.DepthWriteEnabled = depthWriteEnabled;
		this.DepthCompare = depthCompare;
		this.StencilFront = stencilFront;
		this.StencilBack = stencilBack;
		this.StencilReadMask = stencilReadMask;
		this.StencilWriteMask = stencilWriteMask;
		this.DepthBias = depthBias;
		this.DepthBiasSlopeScale = depthBiasSlopeScale;
		this.DepthBiasClamp = depthBiasClamp;
	}

	public DepthStencilState(ChainedStruct* nextInChain = default, TextureFormat format = default, WGPUBool depthWriteEnabled = default, CompareFunction depthCompare = default, StencilFaceState stencilFront = default, StencilFaceState stencilBack = default, uint stencilReadMask = default, uint stencilWriteMask = default, int depthBias = default, float depthBiasSlopeScale = default, float depthBiasClamp = default)
	{
		this.NextInChain = nextInChain;
		this.Format = format;
		this.DepthWriteEnabled = depthWriteEnabled;
		this.DepthCompare = depthCompare;
		this.StencilFront = stencilFront;
		this.StencilBack = stencilBack;
		this.StencilReadMask = stencilReadMask;
		this.StencilWriteMask = stencilWriteMask;
		this.DepthBias = depthBias;
		this.DepthBiasSlopeScale = depthBiasSlopeScale;
		this.DepthBiasClamp = depthBiasClamp;
	}
}

