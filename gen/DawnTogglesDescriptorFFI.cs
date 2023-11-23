using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct DawnTogglesDescriptorFFI
{
	public ChainedStruct Chain;
	public nuint EnabledToggleCount;
	public byte** EnabledToggles;
	public nuint DisabledToggleCount;
	public byte** DisabledToggles;

	public DawnTogglesDescriptorFFI()
	{
		this.Chain = default;
		this.EnabledToggleCount = default;
		this.EnabledToggles = default;
		this.DisabledToggleCount = default;
		this.DisabledToggles = default;
	}

	public DawnTogglesDescriptorFFI(ChainedStruct chain = default, nuint enabledToggleCount = default, byte** enabledToggles = default, nuint disabledToggleCount = default, byte** disabledToggles = default)
	{
		this.Chain = chain;
		this.EnabledToggleCount = enabledToggleCount;
		this.EnabledToggles = enabledToggles;
		this.DisabledToggleCount = disabledToggleCount;
		this.DisabledToggles = disabledToggles;
	}
}

