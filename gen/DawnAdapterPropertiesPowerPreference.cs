using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnAdapterPropertiesPowerPreference
{
	public ChainedStructOut Chain;
	public PowerPreference PowerPreference;

	public DawnAdapterPropertiesPowerPreference()
	{
		this.Chain = default;
		this.PowerPreference = default;
	}

	public DawnAdapterPropertiesPowerPreference(ChainedStructOut chain = default, PowerPreference powerPreference = default)
	{
		this.Chain = chain;
		this.PowerPreference = powerPreference;
	}
}

