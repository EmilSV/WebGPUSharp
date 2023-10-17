using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ImageCopyBufferFFI
{
	public ChainedStruct* NextInChain;
	public TextureDataLayout Layout;
	public BufferHandle Buffer;

	public ImageCopyBufferFFI()
	{
		this.NextInChain = default;
		this.Layout = default;
		this.Buffer = default;
	}

	public ImageCopyBufferFFI(TextureDataLayout layout = default, BufferHandle buffer = default)
	{
		this.Layout = layout;
		this.Buffer = buffer;
	}

	public ImageCopyBufferFFI(ChainedStruct* nextInChain = default, TextureDataLayout layout = default, BufferHandle buffer = default)
	{
		this.NextInChain = nextInChain;
		this.Layout = layout;
		this.Buffer = buffer;
	}
}

