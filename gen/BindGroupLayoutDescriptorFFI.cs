using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BindGroupLayoutDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public nuint EntryCount;
	public BindGroupLayoutEntry* Entries;

	public BindGroupLayoutDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.EntryCount = default;
		this.Entries = default;
	}

	public BindGroupLayoutDescriptorFFI(byte* label = default, nuint entryCount = default, BindGroupLayoutEntry* entries = default)
	{
		this.Label = label;
		this.EntryCount = entryCount;
		this.Entries = entries;
	}

	public BindGroupLayoutDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint entryCount = default, BindGroupLayoutEntry* entries = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.EntryCount = entryCount;
		this.Entries = entries;
	}
}

