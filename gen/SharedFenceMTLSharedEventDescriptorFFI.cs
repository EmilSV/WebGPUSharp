using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct SharedFenceMTLSharedEventDescriptorFFI
{
	public ChainedStruct Chain;
	public void* SharedEvent;

	public SharedFenceMTLSharedEventDescriptorFFI()
	{
		this.Chain = default;
		this.SharedEvent = default;
	}

	public SharedFenceMTLSharedEventDescriptorFFI(ChainedStruct chain = default, void* sharedEvent = default)
	{
		this.Chain = chain;
		this.SharedEvent = sharedEvent;
	}
}

