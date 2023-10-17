using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct DawnTogglesDescriptorFFI
{
	public ChainedStruct Chain;
	public nuint EnabledTogglesCount;
	public byte** EnabledToggles;
	public nuint DisabledTogglesCount;
	public byte** DisabledToggles;

	public DawnTogglesDescriptorFFI()
	{
		this.Chain = default;
		this.EnabledTogglesCount = default;
		this.EnabledToggles = default;
		this.DisabledTogglesCount = default;
		this.DisabledToggles = default;
	}

	public DawnTogglesDescriptorFFI(ChainedStruct chain = default, nuint enabledTogglesCount = default, byte** enabledToggles = default, nuint disabledTogglesCount = default, byte** disabledToggles = default)
	{
		this.Chain = chain;
		this.EnabledTogglesCount = enabledTogglesCount;
		this.EnabledToggles = enabledToggles;
		this.DisabledTogglesCount = disabledTogglesCount;
		this.DisabledToggles = disabledToggles;
	}
}

