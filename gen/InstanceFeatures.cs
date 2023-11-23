using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct InstanceFeatures
{
	public ChainedStruct* NextInChain;
	public WGPUBool TimedWaitAnyEnable;
	public nuint TimedWaitAnyMaxCount;

	public InstanceFeatures()
	{
		this.NextInChain = default;
		this.TimedWaitAnyEnable = default;
		this.TimedWaitAnyMaxCount = default;
	}

	public InstanceFeatures(WGPUBool timedWaitAnyEnable = default, nuint timedWaitAnyMaxCount = default)
	{
		this.TimedWaitAnyEnable = timedWaitAnyEnable;
		this.TimedWaitAnyMaxCount = timedWaitAnyMaxCount;
	}

	public InstanceFeatures(ChainedStruct* nextInChain = default, WGPUBool timedWaitAnyEnable = default, nuint timedWaitAnyMaxCount = default)
	{
		this.NextInChain = nextInChain;
		this.TimedWaitAnyEnable = timedWaitAnyEnable;
		this.TimedWaitAnyMaxCount = timedWaitAnyMaxCount;
	}
}

