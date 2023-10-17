using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public partial struct RenderPassDepthStencilAttachmentFFI
{
	public TextureViewHandle View;
	public LoadOp DepthLoadOp;
	public StoreOp DepthStoreOp;
	public float DepthClearValue;
	public WGPUBool DepthReadOnly;
	public LoadOp StencilLoadOp;
	public StoreOp StencilStoreOp;
	public uint StencilClearValue;
	public WGPUBool StencilReadOnly;

	public RenderPassDepthStencilAttachmentFFI()
	{
		this.View = default;
		this.DepthLoadOp = default;
		this.DepthStoreOp = default;
		this.DepthClearValue = default;
		this.DepthReadOnly = default;
		this.StencilLoadOp = default;
		this.StencilStoreOp = default;
		this.StencilClearValue = default;
		this.StencilReadOnly = default;
	}

	public RenderPassDepthStencilAttachmentFFI(TextureViewHandle view = default, LoadOp depthLoadOp = default, StoreOp depthStoreOp = default, float depthClearValue = default, WGPUBool depthReadOnly = default, LoadOp stencilLoadOp = default, StoreOp stencilStoreOp = default, uint stencilClearValue = default, WGPUBool stencilReadOnly = default)
	{
		this.View = view;
		this.DepthLoadOp = depthLoadOp;
		this.DepthStoreOp = depthStoreOp;
		this.DepthClearValue = depthClearValue;
		this.DepthReadOnly = depthReadOnly;
		this.StencilLoadOp = stencilLoadOp;
		this.StencilStoreOp = stencilStoreOp;
		this.StencilClearValue = stencilClearValue;
		this.StencilReadOnly = stencilReadOnly;
	}
}

