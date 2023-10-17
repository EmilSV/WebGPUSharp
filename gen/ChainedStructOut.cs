using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ChainedStructOut
{
	public ChainedStructOut* Next;
	public SType SType;

	public ChainedStructOut()
	{
		this.Next = default;
		this.SType = default;
	}

	public ChainedStructOut(ChainedStructOut* next = default, SType sType = default)
	{
		this.Next = next;
		this.SType = sType;
	}
}

