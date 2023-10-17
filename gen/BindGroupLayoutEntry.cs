using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BindGroupLayoutEntry
{
	public ChainedStruct* NextInChain;
	public uint Binding;
	public ShaderStage Visibility;
	public BufferBindingLayout Buffer;
	public SamplerBindingLayout Sampler;
	public TextureBindingLayout Texture;
	public StorageTextureBindingLayout StorageTexture;

	public BindGroupLayoutEntry()
	{
		this.NextInChain = default;
		this.Binding = default;
		this.Visibility = default;
		this.Buffer = default;
		this.Sampler = default;
		this.Texture = default;
		this.StorageTexture = default;
	}

	public BindGroupLayoutEntry(uint binding = default, ShaderStage visibility = default, BufferBindingLayout buffer = default, SamplerBindingLayout sampler = default, TextureBindingLayout texture = default, StorageTextureBindingLayout storageTexture = default)
	{
		this.Binding = binding;
		this.Visibility = visibility;
		this.Buffer = buffer;
		this.Sampler = sampler;
		this.Texture = texture;
		this.StorageTexture = storageTexture;
	}

	public BindGroupLayoutEntry(ChainedStruct* nextInChain = default, uint binding = default, ShaderStage visibility = default, BufferBindingLayout buffer = default, SamplerBindingLayout sampler = default, TextureBindingLayout texture = default, StorageTextureBindingLayout storageTexture = default)
	{
		this.NextInChain = nextInChain;
		this.Binding = binding;
		this.Visibility = visibility;
		this.Buffer = buffer;
		this.Sampler = sampler;
		this.Texture = texture;
		this.StorageTexture = storageTexture;
	}
}

