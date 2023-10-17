using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BindGroupEntryFFI
{
	public ChainedStruct* NextInChain;
	public uint Binding;
	public BufferHandle Buffer;
	public ulong Offset;
	public ulong Size;
	public SamplerHandle Sampler;
	public TextureViewHandle TextureView;

	public BindGroupEntryFFI()
	{
		this.NextInChain = default;
		this.Binding = default;
		this.Buffer = default;
		this.Offset = default;
		this.Size = default;
		this.Sampler = default;
		this.TextureView = default;
	}

	public BindGroupEntryFFI(uint binding = default, BufferHandle buffer = default, ulong offset = default, ulong size = default, SamplerHandle sampler = default, TextureViewHandle textureView = default)
	{
		this.Binding = binding;
		this.Buffer = buffer;
		this.Offset = offset;
		this.Size = size;
		this.Sampler = sampler;
		this.TextureView = textureView;
	}

	public BindGroupEntryFFI(ChainedStruct* nextInChain = default, uint binding = default, BufferHandle buffer = default, ulong offset = default, ulong size = default, SamplerHandle sampler = default, TextureViewHandle textureView = default)
	{
		this.NextInChain = nextInChain;
		this.Binding = binding;
		this.Buffer = buffer;
		this.Offset = offset;
		this.Size = size;
		this.Sampler = sampler;
		this.TextureView = textureView;
	}
}

