using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct DawnCacheDeviceDescriptorFFI
{
	public ChainedStruct Chain;
	public byte* IsolationKey;

	public DawnCacheDeviceDescriptorFFI()
	{
		this.Chain = default;
		this.IsolationKey = default;
	}

	public DawnCacheDeviceDescriptorFFI(ChainedStruct chain = default, byte* isolationKey = default)
	{
		this.Chain = chain;
		this.IsolationKey = isolationKey;
	}
}

