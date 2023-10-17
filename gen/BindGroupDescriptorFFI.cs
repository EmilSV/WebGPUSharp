using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BindGroupDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public BindGroupLayoutHandle Layout;
	public nuint EntryCount;
	public BindGroupEntryFFI* Entries;

	public BindGroupDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Layout = default;
		this.EntryCount = default;
		this.Entries = default;
	}

	public BindGroupDescriptorFFI(byte* label = default, BindGroupLayoutHandle layout = default, nuint entryCount = default, BindGroupEntryFFI* entries = default)
	{
		this.Label = label;
		this.Layout = layout;
		this.EntryCount = entryCount;
		this.Entries = entries;
	}

	public BindGroupDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, BindGroupLayoutHandle layout = default, nuint entryCount = default, BindGroupEntryFFI* entries = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.Layout = layout;
		this.EntryCount = entryCount;
		this.Entries = entries;
	}
}

