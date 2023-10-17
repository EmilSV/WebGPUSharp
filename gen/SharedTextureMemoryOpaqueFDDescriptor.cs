using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedTextureMemoryOpaqueFDDescriptor
{
	public ChainedStruct Chain;
	public int MemoryFD;
	public ulong AllocationSize;

	public SharedTextureMemoryOpaqueFDDescriptor()
	{
		this.Chain = default;
		this.MemoryFD = default;
		this.AllocationSize = default;
	}

	public SharedTextureMemoryOpaqueFDDescriptor(ChainedStruct chain = default, int memoryFD = default, ulong allocationSize = default)
	{
		this.Chain = chain;
		this.MemoryFD = memoryFD;
		this.AllocationSize = allocationSize;
	}
}

