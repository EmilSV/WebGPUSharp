using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedTextureMemoryDmaBufDescriptorFFI
{
	public ChainedStruct Chain;
	public int MemoryFD;
	public ulong AllocationSize;
	public ulong DrmModifier;
	public nuint PlaneCount;
	public ulong* PlaneOffsets;
	public uint* PlaneStrides;

	public SharedTextureMemoryDmaBufDescriptorFFI()
	{
		this.Chain = default;
		this.MemoryFD = default;
		this.AllocationSize = default;
		this.DrmModifier = default;
		this.PlaneCount = default;
		this.PlaneOffsets = default;
		this.PlaneStrides = default;
	}

	public SharedTextureMemoryDmaBufDescriptorFFI(ChainedStruct chain = default, int memoryFD = default, ulong allocationSize = default, ulong drmModifier = default, nuint planeCount = default, ulong* planeOffsets = default, uint* planeStrides = default)
	{
		this.Chain = chain;
		this.MemoryFD = memoryFD;
		this.AllocationSize = allocationSize;
		this.DrmModifier = drmModifier;
		this.PlaneCount = planeCount;
		this.PlaneOffsets = planeOffsets;
		this.PlaneStrides = planeStrides;
	}
}

