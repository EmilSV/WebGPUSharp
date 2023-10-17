using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedTextureMemoryZirconHandleDescriptor
{
	public ChainedStruct Chain;
	public uint MemoryFD;
	public ulong AllocationSize;

	public SharedTextureMemoryZirconHandleDescriptor()
	{
		this.Chain = default;
		this.MemoryFD = default;
		this.AllocationSize = default;
	}

	public SharedTextureMemoryZirconHandleDescriptor(ChainedStruct chain = default, uint memoryFD = default, ulong allocationSize = default)
	{
		this.Chain = chain;
		this.MemoryFD = memoryFD;
		this.AllocationSize = allocationSize;
	}
}

