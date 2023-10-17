using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ChainedStruct
{
	public ChainedStruct* Next;
	public SType SType;

	public ChainedStruct()
	{
		this.Next = default;
		this.SType = default;
	}

	public ChainedStruct(SType sType = default)
	{
		this.SType = sType;
	}

	public ChainedStruct(ChainedStruct* next = default, SType sType = default)
	{
		this.Next = next;
		this.SType = sType;
	}
}

