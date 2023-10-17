using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BufferDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public BufferUsage Usage;
	public ulong Size;
	public WGPUBool MappedAtCreation;

	public BufferDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Usage = default;
		this.Size = default;
		this.MappedAtCreation = default;
	}

	public BufferDescriptorFFI(byte* label = default, BufferUsage usage = default, ulong size = default, WGPUBool mappedAtCreation = default)
	{
		this.Label = label;
		this.Usage = usage;
		this.Size = size;
		this.MappedAtCreation = mappedAtCreation;
	}

	public BufferDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, BufferUsage usage = default, ulong size = default, WGPUBool mappedAtCreation = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.Usage = usage;
		this.Size = size;
		this.MappedAtCreation = mappedAtCreation;
	}
}

