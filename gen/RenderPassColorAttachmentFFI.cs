using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RenderPassColorAttachmentFFI
{
	public ChainedStruct* NextInChain;
	public TextureViewHandle View;
	public TextureViewHandle ResolveTarget;
	public LoadOp LoadOp;
	public StoreOp StoreOp;
	public Color ClearValue;

	public RenderPassColorAttachmentFFI()
	{
		this.NextInChain = default;
		this.View = default;
		this.ResolveTarget = default;
		this.LoadOp = default;
		this.StoreOp = default;
		this.ClearValue = default;
	}

	public RenderPassColorAttachmentFFI(TextureViewHandle view = default, TextureViewHandle resolveTarget = default, LoadOp loadOp = default, StoreOp storeOp = default, Color clearValue = default)
	{
		this.View = view;
		this.ResolveTarget = resolveTarget;
		this.LoadOp = loadOp;
		this.StoreOp = storeOp;
		this.ClearValue = clearValue;
	}

	public RenderPassColorAttachmentFFI(ChainedStruct* nextInChain = default, TextureViewHandle view = default, TextureViewHandle resolveTarget = default, LoadOp loadOp = default, StoreOp storeOp = default, Color clearValue = default)
	{
		this.NextInChain = nextInChain;
		this.View = view;
		this.ResolveTarget = resolveTarget;
		this.LoadOp = loadOp;
		this.StoreOp = storeOp;
		this.ClearValue = clearValue;
	}
}

