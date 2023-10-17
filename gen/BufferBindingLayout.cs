using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BufferBindingLayout
{
	public ChainedStruct* NextInChain;
	public BufferBindingType Type;
	public WGPUBool HasDynamicOffset;
	public ulong MinBindingSize;

	public BufferBindingLayout()
	{
		this.NextInChain = default;
		this.Type = default;
		this.HasDynamicOffset = default;
		this.MinBindingSize = default;
	}

	public BufferBindingLayout(BufferBindingType type = default, WGPUBool hasDynamicOffset = default, ulong minBindingSize = default)
	{
		this.Type = type;
		this.HasDynamicOffset = hasDynamicOffset;
		this.MinBindingSize = minBindingSize;
	}

	public BufferBindingLayout(ChainedStruct* nextInChain = default, BufferBindingType type = default, WGPUBool hasDynamicOffset = default, ulong minBindingSize = default)
	{
		this.NextInChain = nextInChain;
		this.Type = type;
		this.HasDynamicOffset = hasDynamicOffset;
		this.MinBindingSize = minBindingSize;
	}
}

