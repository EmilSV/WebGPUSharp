using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedFenceMTLSharedEventExportInfoFFI
{
	public ChainedStructOut Chain;
	public void* SharedEvent;

	public SharedFenceMTLSharedEventExportInfoFFI()
	{
		this.Chain = default;
		this.SharedEvent = default;
	}

	public SharedFenceMTLSharedEventExportInfoFFI(ChainedStructOut chain = default, void* sharedEvent = default)
	{
		this.Chain = chain;
		this.SharedEvent = sharedEvent;
	}
}

