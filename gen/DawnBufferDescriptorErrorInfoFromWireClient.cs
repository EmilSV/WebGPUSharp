using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct DawnBufferDescriptorErrorInfoFromWireClient
{
	public ChainedStruct Chain;
	public WGPUBool OutOfMemory;

	public DawnBufferDescriptorErrorInfoFromWireClient()
	{
		this.Chain = default;
		this.OutOfMemory = default;
	}

	public DawnBufferDescriptorErrorInfoFromWireClient(ChainedStruct chain = default, WGPUBool outOfMemory = default)
	{
		this.Chain = chain;
		this.OutOfMemory = outOfMemory;
	}
}

